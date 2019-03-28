using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBox : Hackable
{
    [SerializeField]
    private GameObject linkedCamera;

    [SerializeField]
    private float downTime;

    private void Start()
    {
        hackProgress = 0;
    }

    

    protected override IEnumerator FinishHack()
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
        linkedCamera.SetActive(false);
    }

    private void ActivateCamera()
    {
        linkedCamera.SetActive(true);
    }
}
