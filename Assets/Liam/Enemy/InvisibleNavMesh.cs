using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleNavMesh : MonoBehaviour
{
    void Start()
    {
        Destroy(GetComponent<MeshRenderer>());
    }

    
}
