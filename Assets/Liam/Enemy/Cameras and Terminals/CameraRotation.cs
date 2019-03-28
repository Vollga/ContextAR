using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    private int angle;

    [SerializeField]
    private float rotationSpeed;

    private Vector3 startRotation;

    private void Start()
    {
        startRotation = transform.rotation.eulerAngles;
    }

    private void Update() {
        transform.rotation = Quaternion.Euler(startRotation.x,startRotation.y + angle * Mathf.Sin(Time.time * rotationSpeed),startRotation.z);
    }
}
