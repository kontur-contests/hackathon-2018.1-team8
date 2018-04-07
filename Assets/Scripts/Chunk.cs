using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {

    public float _moveSpeed;
    public float _deleteEge = -1.8f;
    public event EventHandler BecameInvisible;

    private void Update()
    {
        transform.Translate(new Vector2(-_moveSpeed * Time.deltaTime, 0));
        if (transform.position.x < -1.8f)
            BecameInvisible(gameObject, null);
    }
}
