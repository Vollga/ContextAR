using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public float progressTime;

    Image barImage;
    float fill = 0f;
    float timeStart;
    float timeEnd;
   
    // Start is called before the first frame update
    void Start()
    {
        barImage = gameObject.GetComponent<Image>();
        timeStart = Time.time;
        timeEnd = Time.time + progressTime;
    }

    // Update is called once per frame
    void Update()
    {
        fill = (Time.time - timeStart) / timeEnd;
        barImage.fillAmount = fill;
        if (fill > 1.1f)
        {
            Destroy(gameObject);
        }
    }
}
