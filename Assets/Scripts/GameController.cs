using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public static GameController Instance;
    public RunnerController trackController;

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
        
	}
	
	// Update is called once per frame
	IEnumerator WaitForSecond() {
        yield return new WaitForSeconds(1);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);            
    }
}
