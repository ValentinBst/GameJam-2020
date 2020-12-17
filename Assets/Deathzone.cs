using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Player"))
        {
            Debug.Log("Trigger player");
            Tir balle = other.GetComponent<Tir>();
            balle.ResetPosition();
        }
    }
}