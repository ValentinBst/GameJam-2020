using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    [SerializeField]
    Transform flecheDirectionObjet;

    [SerializeField]
    float forceTirMaximal;

    [SerializeField]
    float tailleMaximaleFleche;

    Camera mainCamera;
    Rigidbody rigidBodyDeLaBalle;
    // Start is called before the first frame update
    [SerializeField]
    private float Mini = 0.5f;

    [SerializeField]
    float tempsPourChargerAuMax = 1f;

    [SerializeField]
    float tempsPourChargerAuMin = 0.25f;

    float timer;
    int sensTimer = 1;
    void Start()
    {
        mainCamera = Camera.main;
        rigidBodyDeLaBalle = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //QUAND LA BALLE EST PRESQUE A L'ARRET (<= Mini)
        if (rigidBodyDeLaBalle.velocity.magnitude <= Mini)
        {
            //J'AFFICHE LA FLECHE DE DIRECTION
            AfficherDirectionFleche();

            //JE STOPPE LA BALLE POUR DE VRAI
            rigidBodyDeLaBalle.velocity = Vector3.zero;

            float force = 0f;

            //SI JE RESTE APPUYE 
            if (Input.GetMouseButton(0))
            {
                //ON AUGMENTE LE TIMER
                timer += Time.deltaTime * sensTimer;

                //SI ON DEPASSE, ON MET LE TIMER A RECULONS
                if(timer >= tempsPourChargerAuMax)
                {
                    sensTimer = -1;
                }
                //SI ON VA TROP BAS, ON MET LE TIMER EN MARCHE AVANT
                else if(timer < tempsPourChargerAuMin)
                {
                    sensTimer = 1;
                }
                //JE CALCULER LE RATIO EN FONCTION DU TEMPS
                float ratio = Mathf.Clamp(timer / tempsPourChargerAuMax, 0f, 1f);

                //ON SCALE LA FLECHE EN FONCTION DU RATIO
                flecheDirectionObjet.localScale = new Vector3(1f, 1f, ratio * tailleMaximaleFleche);
                
                //ON CALCULE LA FORCE DE TIR
                force = forceTirMaximal * ratio;
                Debug.Log(ratio);
            }
            //SI JE RELACHE, J'ENVOIE LA BALLE
            if(Input.GetMouseButtonUp(0) && force > 0f)
            {
                 timer = tempsPourChargerAuMin;
                 Vector3 directionBalle = GetVecteurDirectionBalle();
                //ON ENVOIE LA BALLE
                 rigidBodyDeLaBalle.AddForce(directionBalle * force, ForceMode.Impulse);
            }
        }
        //QUAND LA BALLE EST EN MOUVEMENT
        else if(rigidBodyDeLaBalle.velocity.magnitude > 0.1f)
        {
            CacherDirectionFleche();
        }
    }
    void CacherDirectionFleche()
    {
        flecheDirectionObjet.gameObject.SetActive(false);
    }

    void AfficherDirectionFleche()
    {
        flecheDirectionObjet.gameObject.SetActive(true);

        Vector3 directionBalle = GetVecteurDirectionBalle();

        //On calcule la position vers laquelle tourner la flèche
        Vector3 positionDirection = transform.position + directionBalle * 3f;

        //On tourne la flèche
        flecheDirectionObjet.LookAt(positionDirection);
    }

    Vector3 GetVecteurDirectionBalle()
    {
        //On récupère la position de la caméra
        Vector3 positionCamera = mainCamera.transform.position;
        //On aligne la position sur le Y de la balle
        positionCamera.y = transform.position.y;

        //Direction que doit prendre la balle
        Vector3 directionBalle = (transform.position - positionCamera).normalized;
        return directionBalle;
    }

    private void LateUpdate()
    {
        flecheDirectionObjet.position = transform.position;
    }
}
