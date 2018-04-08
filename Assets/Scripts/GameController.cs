using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController Instance;
    public RunnerController trackController;
    /*public GameObject resultTable;
    public Canvas startMenu;
    public Canvas finishMenu;*/

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
        /*if (startMenu == null) return;
        if (finishMenu == null) return;
        Time.timeScale = 0;
        InitPlayers();*/
	}

    /*void InitPlayers() {
        players = GameObject.FindGameObjectsWithTag("Playable")
            .Select(pgo => pgo.GetComponent<Player>())
            .ToList();
        foreach (Player player in players) {
            var statController = player.gameObject.GetComponent<PlayerStatisticController>();
            statController.onDie += addPlayerToStat;
            statController.onWin += addPlayerToStat;
        }
        finishMenu.gameObject.SetActive(false);
    }*/

    /*public void StartNewGame()
    {
        Time.timeScale = 1;
        startMenu.gameObject.SetActive(false);
        finishMenu.gameObject.SetActive(false);
        InitPlayers();
    }*/

    /*public void RestartGame()
    {
        foreach (Player player in players) {
            player.gameObject.SetActive(true);
            player.Reset();
        }
        Time.timeScale = 1;
        startMenu.gameObject.SetActive(false);
        finishMenu.gameObject.SetActive(false);
    }

    private void ShowFinishMenu() {
        Time.timeScale = 0;
        finishMenu.gameObject.SetActive(true);
    }

    private void addPlayerToStat(object sender, EventArgs args) {
        GameObject senderObject = (GameObject)sender;
        senderObject.SetActive(false);
        int leftPlayers = GameObject.FindGameObjectsWithTag("Playable").Count();
        userScores[senderObject.GetComponent<PlayerStatisticController>().id] += 4 - leftPlayers;
        Debug.Log(senderObject.GetComponent<PlayerStatisticController>().id);
        if (leftPlayers == 1) {
            GameObject winner = GameObject.FindGameObjectWithTag("Playable");
            Debug.Log(winner.GetComponent<PlayerStatisticController>().id);
            userScores[winner.GetComponent<PlayerStatisticController>().id] += 4;
            ShowFinishMenu();
            resultTable.GetComponent<ResultTableController>().results = userScores;
            resultTable.GetComponent<ResultTableController>().ShowStatistics();
        }
    }*/

    
    /*private void ShowTableResults() {
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
        deadPlayer.SetActive(false);
        if (!userScores.ContainsKey(deadPlayerStat.id))
            userScores.Add(deadPlayerStat.id, 4-position);
        else 
            userScores[deadPlayerStat.id] += (4-position);
        stat[position] = new PlayerInfo(deadPlayerStat.info.name, userScores[deadPlayerStat.id]);
    }

    private void AddWinnerToStat(GameObject winner) {
        var winnerStat = winner.GetComponent<PlayerStatisticController>();
        winner.SetActive(false);
        for (int i = 0; i < stat.Length; i++) {
            if (stat[i] != null)
                continue;
            else {
                if (!userScores.ContainsKey(winnerStat.id))
                    userScores.Add(winnerStat.id, 4 - i);
                else
                    userScores[winnerStat.id] += 4 - i;
                stat[i] = new PlayerInfo(winnerStat.info.name, userScores[winnerStat.id]);
                break;
            }
        }
    }*/
	
	// Update is called once per frame
	IEnumerator WaitForSecond() {
        yield return new WaitForSeconds(1);
    }
}
