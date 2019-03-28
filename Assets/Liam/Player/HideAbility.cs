using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class HideAbility : MonoBehaviour
{
    [SerializeField]
    private string hideButton = "Fire1";
    [SerializeField]
    private KeyCode hideKey;
    [SerializeField]
    private int hideRange;
    [SerializeField]
    private int hidingSpotLayer;

    private bool isHiding;

    private RigidbodyFirstPersonController controller;

    private GameObject playerObject;

    private void Start()
    {
        controller = Player.player.gameObject.GetComponent<RigidbodyFirstPersonController>();
        isHiding = false;
        playerObject = Player.player.gameObject;
    }

    private void Update()
    {
        HandleHidingInput();
    }

    //Everything for hiding
    private void HandleHidingInput()
    {
        if (Input.GetButtonDown(hideButton) || Input.GetKeyDown(hideKey))
        {
            if (isHiding)
            {
                Unhide();
            }
            else
            {
                if (InRangeOfHidingSpot())
                {
                    Hide();
                }
            }
        }
    }

    private bool InRangeOfHidingSpot()
    {
        return Physics.Raycast(transform.position, transform.forward, hideRange, 1 << hidingSpotLayer);
    }

    private void Hide()
    {
        controller.enabled = false;
        playerObject.layer = 2;
        isHiding = true;
    }

    private void Unhide()
    {
        controller.enabled = true;
        playerObject.layer = 0;
        isHiding = false;
    }
}
