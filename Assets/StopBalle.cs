using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBalle : MonoBehaviour
{
    [SerializeField]
    private float Mini = 0.5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        float Velo = GetComponent<Rigidbody>().velocity.magnitude;
        if(Velo <= Mini)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
}
