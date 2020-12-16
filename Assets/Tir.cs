using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    [SerializeField]
    Transform flecheDirectionObjet;

    [SerializeField]
    float forceTir;

    Camera mainCamera;
    Rigidbody rigidBodyDeLaBalle;
    // Start is called before the first frame update
    [SerializeField]
    private float Mini = 0.5f;
    void Start()
    {
        mainCamera = Camera.main;
        rigidBodyDeLaBalle = GetComponent<Rigidbody>();
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
        flecheDirectionObjet.LookAt(positionDirection);

        if(Input.GetMouseButtonDown(0))
        {
            rigidBodyDeLaBalle.AddForce(camBalle * forceTir, ForceMode.Impulse);
        }

        //QUAND LA BALLE EST A L'ARRET
        if (rigidBodyDeLaBalle.velocity.magnitude <= Mini)
        {
            rigidBodyDeLaBalle.velocity = Vector3.zero;
            flecheDirectionObjet.gameObject.SetActive(true);
        }
        //QUAND LA BALLE EST EN MOUVEMENT
        else if(rigidBodyDeLaBalle.velocity.magnitude > 0.1f)
        {
            flecheDirectionObjet.gameObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        flecheDirectionObjet.position = transform.position;
    }
}
