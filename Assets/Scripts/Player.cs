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
    private const float StepTime = 0.1f; //допустимая погрешность для игрока
    private const float BaseSpeed = 0.3f;
    private const float SlowSown = 0.3f;

    public Sprite[] sprites = new Sprite[3];
    private SpriteRenderer spriteRenterer;
    private IEnumerator<Sprite> currentSprite;

    public KeyCode lbName;
    public KeyCode rbName;

    private float timer;
    private float slowdownTimer;
    private PlayerState state = PlayerState.None;

    public float PositionX { get; private set; }

    private void Start()
    {
        spriteRenterer = GetComponent<SpriteRenderer>();
        currentSprite = ChangeSprite();
    }

    private void Update()
    {
        Step();
        transform.position = Vector2.Lerp(transform.position,
           new Vector2(PositionX, transform.position.y),
           Time.deltaTime);
    }

    public void Step()
    {
        if (Input.GetKeyDown(lbName))
        {
            //Debug.Log("Try left step");
            switch (state)
            {
                case PlayerState.LeftStep:
                    //Мы нажали кнопку дважды
                    break;
                case PlayerState.RightStep:
                    Debug.Log(timer);
                    PositionX += CalculateAcseleration(timer);
                    timer = 0;
                    state = PlayerState.LeftStep;
                    break;
                case PlayerState.None:
                    state = PlayerState.LeftStep;
                    timer = 0;
                    break;
            }
            currentSprite.MoveNext();
            spriteRenterer.sprite = currentSprite.Current;
        }
        else if (Input.GetKeyDown(rbName))
        {
            //Debug.Log("Try right step");
            switch (state)
            {
                case PlayerState.LeftStep:
                    Debug.Log(timer);
                    PositionX += CalculateAcseleration(timer);
                    timer = 0;
                    state = PlayerState.RightStep;
                    break;
                case PlayerState.RightStep:
                    //Мы нажали кнопку дважды
                    break;
                case PlayerState.None:
                    state = PlayerState.RightStep;
                    timer = 0;
                    break;
            }
            currentSprite.MoveNext();
            spriteRenterer.sprite = currentSprite.Current;
        }
        
        if (state != PlayerState.None)
            timer += Time.deltaTime;
       if (slowdownTimer > OptimalDeltaTime)
        {
            PositionX -= SlowSown;
            slowdownTimer = 0;
        }
        slowdownTimer += Time.deltaTime;
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
        float x = Mathf.Abs(deltaTime - OptimalDeltaTime);
        var diviation = x / StepTime;
        if (diviation == 0) return BaseSpeed;
        var acc = Mathf.Clamp(BaseSpeed / diviation, 0, BaseSpeed);
        return acc;
    }
}
