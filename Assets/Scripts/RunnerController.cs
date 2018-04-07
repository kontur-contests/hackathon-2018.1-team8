using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerController : MonoBehaviour {
    
    public Transform _chunkPrefab;
    private Transform[] _currentChunks = new Transform[3];
    private Transform currentChunk;
    private float chunkSize = 2.0f;

	// Use this for initialization
	void Start () {
        var pos = transform.position;
        for (int i = 0; i < _currentChunks.Length; i ++)
        {
            var newChunkPos = new Vector2(pos.x + chunkSize * i, pos.y);
            var newChunk = Instantiate(_chunkPrefab, newChunkPos, Quaternion.identity);
            newChunk.GetComponent<Chunk>().BecameInvisible += DeleteAndSpawnChunk;
            _currentChunks[i] = newChunk;
            
        }
	}
	
	// Update is called once per frame
	void Update () {
        /*foreach (var ch in _currentChunks)
        {
            ch.transform.Translate(new Vector2(-_moveSpeed * Time.deltaTime, 0));
        }*/
	}

    private void DeleteAndSpawnChunk(object sender, EventArgs args)
    {
        var chunkGo = (GameObject)sender;
        chunkGo.GetComponent<Chunk>().BecameInvisible -= DeleteAndSpawnChunk;
        Destroy(chunkGo);

    }
}
