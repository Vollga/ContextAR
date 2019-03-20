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
    }
    

    // Update is called once per frame
    void Update()
    {
        if (_isDiscovered != _check)
        {
            _check = _isDiscovered;

            if (_isDiscovered)
            {
                print("You're discovered!");
                discoveredOverlay.SetActive(true);
                ChangeUIColour(UIBorders, color_Discovered);

            } else if (!_isDiscovered)
            {
                print("You're not discovered!");
                discoveredOverlay.SetActive(false);
                ChangeUIColour(UIBorders, color_Normal);
            }
        }
    }

    void ChangeUIColour(GameObject[] gObjects, Color color)
    {
        for(int i = 0; i < gObjects.Length; i++)
        {
            gObjects[i].GetComponent<Image>().color = color;
        }
    }
}
