using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
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
	public string playerName;
	public int id;

	public PlayerInfo info;
	
	// Update is called once per frame
	void Start() {
		info = new PlayerInfo(playerName, 0);
	}
	void Update () {
        if (transform.position.x < -5f)
            onDie(gameObject, null);
        else if (transform.position.x > 10.5f)
            onWin(gameObject, null);
	}
}
