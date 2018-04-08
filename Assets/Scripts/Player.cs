using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    None, RightStep, LeftStep
}

public class Player : MonoBehaviour
{
    private const float OptimalDeltaTime = 0.2f;
    private const float StepTime = 0.2f; //допустимая погрешность для игрока
    private const float BaseSpeed = 0.4f;
    private const float SlowSown = 0.3f;
    private const float JumpForce = 12;
    private const float Gravity = 60;

    public Sprite[] sprites = new Sprite[3];
    private SpriteRenderer spriteRenterer;
    private IEnumerator<Sprite> currentSprite;
    private PlayerAudioSource audioSource;
    public Vector3 cacheStartPosition;

    public KeyCode lbName;
    public KeyCode rbName;

    private float timer;
    private PlayerState state = PlayerState.None;

    public float PositionX { get; private set; }
    private bool runDisabled = false;
    //public float PositionY { get; private set; }
    private float vSpeed;
    public bool IsJumping { get; private set; }
    private float floor;

    public void DisableRun(float time)
    {
        audioSource.PlayClip("hit");
        if (gameObject.activeInHierarchy)
            StartCoroutine(DisableRunCorutine(time));
    }

    private IEnumerator DisableRunCorutine(float time)
    {
        runDisabled = true;
        yield return new WaitForSeconds(time);
        runDisabled = false;
    }

    private void Start()
    {
        floor = transform.position.y;
        spriteRenterer = GetComponent<SpriteRenderer>();
        currentSprite = ChangeSprite();
        StartCoroutine(SlowDown());
        PositionX = transform.position.x;
        cacheStartPosition = this.transform.position;
        audioSource = transform.Find("PlayerAudioSource").GetComponent<PlayerAudioSource>();
    }

    private void Update()
    {
        Step();
        transform.position = Vector2.Lerp(transform.position,
           new Vector2(PositionX, transform.position.y),
           Time.deltaTime);
    }

    public void Reset() {
        this.transform.SetPositionAndRotation(cacheStartPosition, Quaternion.identity);
        timer = 0;
        state = PlayerState.None;
        PositionX = cacheStartPosition.x;
        StartCoroutine(SlowDown());
        IsJumping = false;
    }

    private void Step()
    {
        if (Input.GetKeyDown(lbName) && Input.GetKeyDown(rbName))
        {
            if(!IsJumping)
            {
                vSpeed = JumpForce;
                IsJumping = true;
                audioSource.PlayClip("jump", 0.15f);
            }
        }
        else if (Input.GetKeyDown(lbName))
        {
            switch (state)
            {
                case PlayerState.LeftStep:
                    //Мы нажали кнопку дважды
                    break;
                case PlayerState.RightStep:
                    PositionX += CalculateAcseleration(timer);
                    timer = 0;
                    state = PlayerState.LeftStep;
                    currentSprite.MoveNext();
                    spriteRenterer.sprite = currentSprite.Current;
                    audioSource.PlayClip("step1", 0.15f);
                    break;
                case PlayerState.None:
                    state = PlayerState.LeftStep;
                    timer = 0;
                    break;
            }
            
        }
        else if (Input.GetKeyDown(rbName))
        {
            switch (state)
            {
                case PlayerState.LeftStep:
                    PositionX += CalculateAcseleration(timer);
                    timer = 0;
                    state = PlayerState.RightStep;
                    currentSprite.MoveNext();
                    spriteRenterer.sprite = currentSprite.Current;
                    audioSource.PlayClip("step2", 0.15f);
                    break;
                case PlayerState.RightStep:
                    //Мы нажали кнопку дважды
                    break;
                case PlayerState.None:
                    state = PlayerState.RightStep;
                    timer = 0;
                    break;
            }
        }
        if (state != PlayerState.None)
            timer += Time.deltaTime;
        if (IsJumping)
        {
            transform.Translate(new Vector2(0, vSpeed * Time.deltaTime));
            vSpeed -= Gravity * Time.deltaTime;
            if (transform.position.y < floor)
            {
                transform.position = new Vector2(transform.position.x, floor);
                IsJumping = false;
            }
        }
        
    }

    private IEnumerator SlowDown()
    {
        while (true)
        {
            PositionX -= SlowSown;
            yield return new WaitForSeconds(OptimalDeltaTime);
        }
    }

    private IEnumerator<Sprite> ChangeSprite()
    {
        while (true)
        {
            yield return sprites[0];
            yield return sprites[1];
            yield return sprites[0];
            yield return sprites[2];
        }
    }
     
    private float CalculateAcseleration(float deltaTime)
    {
        if (runDisabled) return 0;
        float x = Mathf.Abs(deltaTime - OptimalDeltaTime);
        var diviation = x / StepTime;
        if (diviation == 0) return BaseSpeed;
        var acc = Mathf.Clamp(BaseSpeed / diviation, 0, BaseSpeed);
        return acc;
    }
}
