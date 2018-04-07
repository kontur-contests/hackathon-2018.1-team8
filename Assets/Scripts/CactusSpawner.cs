using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusSpawner : MonoBehaviour {

    public Player player;
    public Transform cactus;
    public float spanTime;
    public float spawnBias;
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnCactus());
	}
	
	private IEnumerator SpawnCactus()
    {
        while (true)
        {
            var newCactus = Instantiate(cactus, transform.position, Quaternion.identity);
            var cactusComponent = newCactus.GetComponent<Cactus>();
            cactusComponent.player = player;
            yield return new WaitForSeconds(spanTime + Random.Range(-spawnBias, spawnBias));
        }
    }
}
