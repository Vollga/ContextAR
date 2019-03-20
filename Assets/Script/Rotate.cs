using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    
    [SerializeField]
    private float speed;
    
	void FixedUpdate () {
		transform.Rotate(Vector3.up * Time.deltaTime * speed);
	}
}
