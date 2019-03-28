using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHack : MonoBehaviour
{
    [SerializeField]
    private float hackRange = 2;

    [SerializeField]
    private float hackSpeed = 1;

    [SerializeField]
    private string hackButton = "Fire1";

    //[SerializeField]
    //private GameObject hackProgressBar;

    private Hackable currentlyHackedObject;
    private int cameraBoxLayer = 9;
    //private GameObject instantiatedHackBar;

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * hackRange, Color.red);
        if (Input.GetButtonDown(hackButton)) {
            DetectCameraBox();
            //if(currentlyHackedObject != null)
            //instantiatedHackBar = Instantiate(hackProgressBar, GameObject.Find("Canvas").transform);
        }

        if (Input.GetButton(hackButton)) {
            if (currentlyHackedObject != null && !currentlyHackedObject.IsHacked()) {
                currentlyHackedObject.HackCamera(hackSpeed * Time.deltaTime);
            }
        }

        if (Input.GetButtonUp(hackButton)) {
            if (currentlyHackedObject != null)
            {
                //if (instantiatedHackBar != null) {
                //    Destroy(instantiatedHackBar);
                //}
                currentlyHackedObject.StopHacking();
                currentlyHackedObject = null;
            }
        }
    }

    private void DetectCameraBox() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, hackRange, 1<<cameraBoxLayer)) {
            currentlyHackedObject = hit.transform.gameObject.GetComponent<Hackable>();
            return;
        }
        currentlyHackedObject = null;
    }
}
