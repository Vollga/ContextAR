using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int timeToRespawnAfterGettingSpotted;

    [SerializeField]
    private GameObject startingCheckpoint;

    private Vector3 checkpointPosition;

    public event Action spotted;
    public event Action respawned;

    public static Player player;

    private bool hasBeenSpotted;

    private RigidbodyFirstPersonController firstPersonController;

    private void Awake()
    {
        firstPersonController = gameObject.GetComponent<RigidbodyFirstPersonController>();

        if (player == null) {
            player = this;
        }
    }

    private void Start()
    {
        //Respawn();
        hasBeenSpotted = false;
        checkpointPosition = startingCheckpoint.transform.position;
    }


    //Everything for getting spotted in general
    //---------------------------------------------------------------------------------------
    public void Spotted() {
        //TODO Change UI or whatever
        Debug.Log("Just spotted by something!");
        if (spotted != null)
        {
            spotted();
        }
        firstPersonController.enabled = false;
        Invoke("Respawn", timeToRespawnAfterGettingSpotted);
    }

    public bool HasBeenSpotted
    {
        get { return hasBeenSpotted; }
        set
        {
            hasBeenSpotted = value;
            Spotted();
        }
    }

    public void SetCheckpoint(Vector3 position)
    {
        checkpointPosition = position;
    }

    public void Respawn() {
        if (respawned != null)
        {
            respawned();
        }
        hasBeenSpotted = false;
        firstPersonController.enabled = true;
        transform.position = checkpointPosition;
    }
}
