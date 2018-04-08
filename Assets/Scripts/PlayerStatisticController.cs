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

	
    public event EventHandler onDie;
    public event EventHandler onWin;
	public string playerName;
	public int id;

	public PlayerInfo info;
	
	// Update is called once per frame
	void Start() {
		info = new PlayerInfo(playerName, 0);
	}

    public void Die()
    {
        onDie(gameObject, null);
    }

    public void Win()
    {
        onWin(gameObject, null);
    }
    /*void Update () {
        if (transform.position.x < -5f)
            
        else if (transform.position.x > 10.5f)
            
	}*/
}
