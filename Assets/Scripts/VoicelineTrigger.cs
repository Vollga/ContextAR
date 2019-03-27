using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoicelineTrigger : MonoBehaviour
{
    AudioSource voiceClip;
    bool _hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        voiceClip = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("Player")) && (_hasPlayed == false)){
            voiceClip.Play();
            _hasPlayed = true;
        }
    }
}
