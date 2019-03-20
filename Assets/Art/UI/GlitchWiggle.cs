using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchWiggle : MonoBehaviour
{
    private int random_x;
    private int random_y;
    private RectTransform rectTrans;

    // Start is called before the first frame update
    void Start()
    {
        rectTrans = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Time.frameCount % 10 == Random.Range(0,3)) {
            random_x = Random.Range(0, 100);
            random_y = Random.Range(0, 100);
            rectTrans.localScale = new Vector3(Random.Range(1,1.05f), Random.Range(1, 1.05f), 1);
            rectTrans.offsetMin = new Vector2(random_x, random_y);
            rectTrans.offsetMax = new Vector2(random_x, random_y);
            if (Random.Range(0, 5) < 4)
            {
                rectTrans.localScale = new Vector3(-1.2f, 1.2f, 1);
            }
            if (Random.Range(0, 5) < 4)
            {
                rectTrans.localScale = new Vector3(1.2f, -1.2f, 1);
            }
        }
        
    }
}
