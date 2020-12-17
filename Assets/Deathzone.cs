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
            Balle balle = other.GetComponent<Balle>();
            balle.ResetPositionAuDernierTir();
        }
    }
}