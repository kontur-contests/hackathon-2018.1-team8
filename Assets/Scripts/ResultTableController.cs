using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResultTableController : MonoBehaviour {

	// Use this for initialization
	public GameObject[] names = new GameObject[4];
	public GameObject[] scores = new GameObject[4];
	public int[] results = new int[4]; //очки пользователей по окончанию забега
	public void ShowStatistics() {
		for(int i = 0; i < results.Length; i++) {
			names[i].GetComponent<Text>().text = "Player " + i;
			scores[i].GetComponent<Text>().text = results[i].ToString();
		}
	}  
}
