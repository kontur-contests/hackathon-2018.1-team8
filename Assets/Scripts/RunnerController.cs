using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RunnerController : MonoBehaviour
{

    public Transform _chunkPrefab;
    private Transform[] _currentChunks = new Transform[3];
    private Transform currentChunk;
    private float chunkSize = 13.52f;

    // Use this for initialization
    void Start()
    {
        var pos = transform.position;
        for (int i = 0; i < _currentChunks.Length; i++)
        {
            var newChunkPos = new Vector2(pos.x + chunkSize * i, pos.y);
            CreateChunk(i, newChunkPos);

        }
    }

    // Update is called once per frame
    void Update()
    {
        /*foreach (var ch in _currentChunks)
        {
            ch.transform.Translate(new Vector2(-_moveSpeed * Time.deltaTime, 0));
        }*/
    }

    private void CreateChunk(int idx, Vector2 pos)
    {
        var newChunk = Instantiate(_chunkPrefab, pos, Quaternion.identity);
        newChunk.GetComponent<Chunk>().BecameInvisible += DeleteAndSpawnChunk;
        _currentChunks[idx] = newChunk;
    }

    private void DeleteAndSpawnChunk(object sender, EventArgs args)
    {
        var chunkGo = (GameObject)sender;
        chunkGo.GetComponent<Chunk>().BecameInvisible -= DeleteAndSpawnChunk;
        for (int i = 0; i < _currentChunks.Length; i++)
        {
            if (_currentChunks[i].gameObject == chunkGo)
            {
                CreateChunk(i, new Vector2(transform.position.x + chunkSize * 1.5f, transform.position.y));
            }
        }
        Destroy(chunkGo);
    }
}
