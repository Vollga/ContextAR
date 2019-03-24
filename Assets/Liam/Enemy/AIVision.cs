using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVision : MonoBehaviour
{
    private GameObject player;

    [SerializeField]
    private float visionRange;
    [SerializeField]
    private float visionAngle;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (PlayerInVision())
        {
            Debug.Log("Player In Vision");
        }
        else
        {
            Debug.Log("Player Out Of Vision");
        }
    }

    public bool PlayerInVision()
    {
        bool playerInVision = false;
        if (PlayerInVisionAngle()) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, player.transform.position-transform.position, out hit, visionRange)) {
                if (hit.transform.gameObject == player) {
                    playerInVision = true;
                }
            }
        }
        return playerInVision;
    }

    private bool PlayerInVisionAngle()
    {
        Vector3 vectorToPlayer = player.transform.position - transform.position;
        return Vector3.Angle(vectorToPlayer, transform.forward) < visionAngle;
    }
}
