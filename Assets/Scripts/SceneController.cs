using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	
    public UnityEngine.Object NextScene;
	public void LoadNextLevel() {
        SceneManager.LoadScene(NextScene.name);
    }
}
