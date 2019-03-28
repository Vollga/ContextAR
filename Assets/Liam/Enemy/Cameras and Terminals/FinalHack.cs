using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalHack : Hackable
{
    protected override IEnumerator FinishHack()
    {
        Debug.Log("GameOver");
        hacked = true;
        //Start outro somehow
        yield return null;
    }
}
