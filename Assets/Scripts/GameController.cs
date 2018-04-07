using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController Instance;
    public RunnerController trackController;
    public GameObject resultTable;
    public List<Player> players = new List<Player>();
    public PlayerInfo[] stat = new PlayerInfo[4];
    public Canvas startMenu;
    public Canvas finishMenu;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
    // Use this for initialization
    void Start ()
    {
        if (startMenu == null) return;
        if (finishMenu == null) return;
        Time.timeScale = 0;
        finishMenu.gameObject.SetActive(false);
        foreach (Player player in players) {
            player.gameObject.GetComponent<PlayerStatisticController>().onDie += AddDeadPlayerToStat;
            player.gameObject.GetComponent<PlayerStatisticController>().onWin += AddWinPlayerToStat;
        }
	}

    public void StartNewGame()
    {
        Time.timeScale = 1;
        startMenu.gameObject.SetActive(false);
    }

    private void ShowFinishMenu() {
        Time.timeScale = 0;
        finishMenu.gameObject.SetActive(true);
    }

    
    private void ShowTableResults() {
            resultTable.GetComponent<ResultTableController>().info = stat;
            resultTable.GetComponent<ResultTableController>().ShowStatistics();
            ShowFinishMenu();
    }
    private void AddDeadPlayerToStat(object sender, EventArgs args) {
        var userCount = GameObject.FindGameObjectsWithTag("Playable").Length-1;
        if (userCount > 1) {
            GameObject deadPlayer = (GameObject)sender;
            AddDeadManToStat(deadPlayer, userCount);
        }
        else {
            GameObject deadPlayer = (GameObject)sender;
            AddDeadManToStat(deadPlayer, userCount);
            GameObject winner = GameObject.FindGameObjectWithTag("Playable");
            AddWinnerToStat(winner);
            ShowTableResults();
        }
    }

    private void AddWinPlayerToStat(object sender, EventArgs args) {
        var userCount = GameObject.FindGameObjectsWithTag("Playable").Length-1;
        if (userCount > 1) {
            GameObject winner = (GameObject)sender;
            AddWinnerToStat(winner);
        }
        else {
            GameObject winner = (GameObject)sender;
            AddWinnerToStat(winner);
            winner = GameObject.FindGameObjectWithTag("Playable");
            AddWinnerToStat(winner);
            ShowTableResults();
        }
    }

    private void AddDeadManToStat(GameObject deadPlayer, int position) {
        PlayerStatisticController deadPlayerStat = deadPlayer.GetComponent<PlayerStatisticController>();
        DestroyImmediate(deadPlayer);
        stat[position] = new PlayerInfo(deadPlayerStat.info.name, deadPlayerStat.info.score + 4 - position);
    }

    private void AddWinnerToStat(GameObject winner) {
        PlayerStatisticController winnerStat = winner.GetComponent<PlayerStatisticController>();
        DestroyImmediate(winner);
        for (int i = 0; i < stat.Length; i++) {
            if (stat[i] != null)
                continue;
            else {
                stat[i] = new PlayerInfo(winnerStat.info.name, winnerStat.info.score + (4 -i));
                break;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
