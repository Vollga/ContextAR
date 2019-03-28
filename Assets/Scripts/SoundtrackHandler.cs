using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackHandler : MonoBehaviour
{
    [SerializeField]
    private AudioClip idleLoop;

    [SerializeField]
    private AudioClip detected;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        Player.player.spotted += OnDetection;
        Player.player.respawned += OnRespawn;
    }

    void OnRespawn() {
        source.clip = idleLoop;
        source.Play();
    }

    void OnDetection() {
        source.clip = detected;
        source.Play();
    }
}
