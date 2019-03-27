using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DepleteBar : MonoBehaviour
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
        timeStart = Time.unscaledTime;
        timeEnd = Time.unscaledTime + progressTime;
    }

    // Update is called once per frame
    void Update()
    {
        fill = 1f-(Time.unscaledTime - timeStart) / timeEnd;
        barImage.fillAmount = fill;
        if (fill > 1.1f)
        {
            Destroy(gameObject);
        }
    }
}
