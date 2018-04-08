using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooseTrigger : MonoBehaviour {

    // Use this for initialization
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerStatisticController>();
        if (player == null) return;
        Debug.Log("Somebody loose");
        player.Die();
    }
}
