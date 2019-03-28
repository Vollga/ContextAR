using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player.player.gameObject) {
            Player.player.SetCheckpoint(transform.position);
            Destroy(gameObject.GetComponent<BoxCollider>());
        }
    }
}
