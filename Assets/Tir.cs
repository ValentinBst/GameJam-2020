using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    public int SpeedRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = GameObject.Find("Balle").GetComponent<Transform>().position;
        transform.eulerAngles = Vector3.up * Input.GetAxis("Mouse X");
    }
}
