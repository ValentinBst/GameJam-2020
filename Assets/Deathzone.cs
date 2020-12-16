using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{

    public Vector3 respawnPositions;

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trigger player");
            other.transform.position = respawnPositions;
        }
    }
}