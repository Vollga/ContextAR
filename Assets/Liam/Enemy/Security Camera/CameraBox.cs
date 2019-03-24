using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBox : MonoBehaviour
{
    [SerializeField]
    private GameObject linkedCamera;

    [SerializeField]
    private float downTime;

    [SerializeField]
    private float maxHackTime = 100;

    private bool hacked = false;
    private float hackProgress;

    

    private AIVision cameraVision;

    private void Start()
    {
        hackProgress = 0;
        cameraVision = linkedCamera.GetComponent<AIVision>();
    }

    public bool IsHacked() {
        return hacked;
    }

    public void HackCamera(float progressIncrease)
    {
        Debug.Log("Hacking: " + (int)hackProgress);
        hackProgress += progressIncrease;
        if (hackProgress >= maxHackTime) {
            StartCoroutine(FinishHack());
        }
    }

    public void StopHacking() {
        Debug.Log("Stopped Hacking");
        hackProgress = 0;
    }

    private IEnumerator FinishHack()
    {
            Debug.Log("Hacked");
            hacked = true;
            DeactivateCamera();
            yield return new WaitForSeconds(downTime);
            ActivateCamera();
            hacked = false;
            hackProgress = 0;
    }

    private void DeactivateCamera()
    {
        cameraVision.enabled = false;
    }

    private void ActivateCamera()
    {
        cameraVision.enabled = true;
    }
}
