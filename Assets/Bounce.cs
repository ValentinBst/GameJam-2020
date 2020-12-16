using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _avoidanceForce = 4;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody other = collision.transform.GetComponent<Rigidbody>();
            //Debug.Log("Avoiding " + other.name);
            other.AddExplosionForce(
               _avoidanceForce,
               collision.contacts[0].point,
               1,
               0,
               ForceMode.VelocityChange
           );
        }
    }
}
