using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo {
	public string name;
	public int score;

	public PlayerInfo(string name, int score) {
		this.name = name;
		this.score = score;
	}
}

public class PlayerStatisticController : MonoBehaviour {

	
    public EventHandler onDie;
    public EventHandler onWin;
	public string name;

	public PlayerInfo info = new PlayerInfo("undefined", 0);
	
	// Update is called once per frame
	void Start() {
		info = new PlayerInfo(name, 0);
	}
	void Update () {
        if (transform.position.x < -5f)
            onDie(gameObject, null);
        else if (transform.position.x > 10.5f)
            onWin(gameObject, null);
	}
}
