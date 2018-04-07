using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RunnerController : MonoBehaviour
{
    public float speedEditorControl = 1;
    private float _moveSpeed = 1;

    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set
        {
            if (_moveSpeed == value) return;
            _moveSpeed = value;
            foreach (var chunk in _currentChunks)
            {
                chunk.moveSpeed = _moveSpeed;
            }
        }
    }

    public Transform _chunkPrefab;
    private Chunk[] _currentChunks = new Chunk[3];
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

    private void Update()
    {
        MoveSpeed = speedEditorControl;
    }

    private void CreateChunk(int idx, Vector2 pos)
    {
        var newChunk = Instantiate(_chunkPrefab, pos, Quaternion.identity);
        var chunkComponent = newChunk.GetComponent<Chunk>();
        chunkComponent.moveSpeed = _moveSpeed;
        chunkComponent.BecameInvisible += DeleteAndSpawnChunk;
        _currentChunks[idx] = chunkComponent;
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
