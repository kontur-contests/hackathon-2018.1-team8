using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController Instance;
    public RunnerController trackController;
    public List<Player> players = new List<Player>();
    public Canvas menu;

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
        if (menu == null) return;
        Time.timeScale = 0;
	}

    public void StartNewGame()
    {
        Time.timeScale = 1;
        menu.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

	}
}
