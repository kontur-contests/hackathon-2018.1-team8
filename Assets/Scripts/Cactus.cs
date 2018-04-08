using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour {

    public Player player;
    public float radius = 0.1f;
    public float speed = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var deltax = Mathf.Abs(player.transform.position.x - transform.position.x);
        //Debug.Log(player.IsJumping);
		if (deltax < radius && !player.IsJumping)
        {
            player.DisableRun(2.5f);
        }
        transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
	}
}
