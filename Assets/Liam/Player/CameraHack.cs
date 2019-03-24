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

    private CameraBox currentlyHackedCameraBox;
    private int cameraBoxLayer = 9;

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * hackRange, Color.red);
        if (Input.GetButtonDown(hackButton)) {
            DetectCameraBox();
        }

        if (Input.GetButton(hackButton)) {
            if (currentlyHackedCameraBox != null && !currentlyHackedCameraBox.IsHacked()) {
                currentlyHackedCameraBox.HackCamera(hackSpeed * Time.deltaTime);
            }
        }

        if (Input.GetButtonUp(hackButton)) {
            if (currentlyHackedCameraBox != null)
            {
                currentlyHackedCameraBox.StopHacking();
                currentlyHackedCameraBox = null;
            }
        }
    }

    private void DetectCameraBox() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, hackRange, 1<<cameraBoxLayer)) {
            currentlyHackedCameraBox = hit.transform.gameObject.GetComponent<CameraBox>();
            return;
        }
        currentlyHackedCameraBox = null;
    }
}
