using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
[SerializeField]
    Transform destination;

    void OnCollisionStay(Collision col) {

        if (col.rigidbody.velocity.magnitude < 0.1f) {

            col.transform.position = destination.position;
            col.transform.GetComponent<Balle>().positionDeDepart = destination.position;
        }
        
    }
}
