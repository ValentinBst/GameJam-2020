using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    [SerializeField]
    Transform directionGizmo;

    [SerializeField]
    float forceTir;

    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //transform.eulerAngles = Vector3.up * Input.GetAxis("Mouse X");

        Vector3 positionCamera = mainCamera.transform.position;
        positionCamera.y = transform.position.y;
        
        //Direction que doit prendre la balle
        Vector3 camBalle = (transform.position - positionCamera).normalized;


        Vector3 positionDirection = transform.position + camBalle * 3f;
        directionGizmo.LookAt(positionDirection);

        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody>().AddForce(camBalle * forceTir, ForceMode.Impulse);
        }
    }

    private void LateUpdate()
    {
        directionGizmo.position = transform.position;
    }
}
