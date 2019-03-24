using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ReplacementShaderEffect))]
public class XRayVision : MonoBehaviour
{
    [SerializeField]
    private string xrayButton = "Fire2";

    [SerializeField]
    private int maxXrayDuration = 5;

    [SerializeField]
    private int maxCooldownTime = 5;

    private bool onCooldown = false;
    private float xrayTimeRemaining;
    private float cooldownTimeRemaining;
    private ReplacementShaderEffect xrayEffect;

    private void Start()
    {
        xrayTimeRemaining = maxXrayDuration;
        cooldownTimeRemaining = maxCooldownTime;
        xrayEffect = GetComponent<ReplacementShaderEffect>();
        StopXray();
    }

    private void StartXray()
    {
        xrayEffect.enabled = true;
    }

    private void StopXray()
    {
        xrayEffect.enabled = false;
        xrayTimeRemaining = maxXrayDuration;
    }

    private void Update()
    {
        if (xrayEffect.enabled)
        {
            HandleActiveXray();
        }
        else if (onCooldown)
        {
            HandleXrayOnCooldown();
        }
        else if (Input.GetButtonDown(xrayButton))
        {
            HandleXrayInput();
        }
    }

    private void HandleXrayInput()
    {
            if (!xrayEffect.enabled && !onCooldown)
            {
                StartXray();
            }
    }

    private void HandleActiveXray()
    {
        xrayTimeRemaining -= Time.deltaTime;
        if (xrayTimeRemaining <= 0)
        {
            StopXray();
            onCooldown = true;
        }
    }

    private void HandleXrayOnCooldown()
    {
        cooldownTimeRemaining -= Time.deltaTime;
        if (cooldownTimeRemaining <= 0)
        {
            onCooldown = false;
            cooldownTimeRemaining = maxCooldownTime;
        }
    }

}
