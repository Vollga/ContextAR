using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [Header ("Discovered UI Settings")]
    public bool _isDiscovered = false;
    public GameObject discoveredOverlay;
    public Color color_Normal;
    public Color color_Discovered;

    private bool _check;
    private GameObject[] UIBorders;
    

    // Start is called before the first frame update
    void Start()
    {
        UIBorders = GameObject.FindGameObjectsWithTag("UI_Border");
        OnRespawn();
        Player.player.spotted += OnDiscovery;
        Player.player.respawned += OnRespawn;
    }

    public void OnDiscovery() {
        discoveredOverlay.SetActive(true);
        ChangeUIColour(UIBorders, color_Discovered);
    }

    public void OnRespawn() {
        discoveredOverlay.SetActive(false);
        ChangeUIColour(UIBorders, color_Normal);
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    if (_isDiscovered != _check)
    //    {
    //        _check = _isDiscovered;

    //        if (_isDiscovered)
    //        {
    //            print("You're discovered!");
                

    //        } else if (!_isDiscovered)
    //        {
    //            print("You're not discovered!");
                
    //        }
    //    }
    //}

    void ChangeUIColour(GameObject[] gObjects, Color color)
    {
        for(int i = 0; i < gObjects.Length; i++)
        {
            gObjects[i].GetComponent<Image>().color = color;
        }
    }
}
