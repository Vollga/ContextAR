using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hackable : MonoBehaviour
{

    [SerializeField]
    protected float maxHackTime = 100;

    

    protected bool hacked = false;
    protected float hackProgress = 0;

    public void HackCamera(float progressIncrease)
    {
        Debug.Log("Hacking: " + (int)hackProgress);
        hackProgress += progressIncrease;
        if (hackProgress >= maxHackTime)
        {
            StartCoroutine(FinishHack());
        }
    }

    public void StopHacking()
    {
        Debug.Log("Stopped Hacking");
        hackProgress = 0;
    }

    public bool IsHacked()
    {
        return hacked;
    }

    protected abstract IEnumerator FinishHack();
}
