using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teleport : MonoBehaviour {
[SerializeField]
    Transform destination;

    [SerializeField]
    bool isFinal = false;
    [SerializeField]
    UnityEvent reachAction;

    void OnCollisionStay(Collision col) {

        if (col.rigidbody.velocity.magnitude < 0.1f) {

            if(!isFinal)
            {
                col.transform.position = destination.position;
                col.transform.GetComponent<Balle>().positionDeDepart = destination.position;
                destination.GetComponent<CamEffect>()?.ShowEffect();
            }
            else
            {
                reachAction?.Invoke();
            }
        }
        
    }
}
