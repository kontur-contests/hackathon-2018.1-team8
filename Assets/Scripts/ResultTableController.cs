using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResultTableController : MonoBehaviour {

	// Use this for initialization
	public GameObject[] names = new GameObject[4];
	public GameObject[] scores = new GameObject[4];
	public PlayerInfo[] info = new PlayerInfo[4];
	public void ShowStatistics() {
		info.Reverse();
		for(int i = 0; i < info.Length; i++) {
			names[i].GetComponent<Text>().text = info[i].name;
			scores[i].GetComponent<Text>().text = info[i].score.ToString();
		}
	}  
}
