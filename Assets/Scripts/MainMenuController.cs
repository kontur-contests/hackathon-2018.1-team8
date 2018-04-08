using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	// Use this for initialization
	public void Exit() {
		Application.Quit();
	}

	public void LoadFirstLevel() {
		SceneManager.LoadScene("Runner");
	}
}
