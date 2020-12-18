using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
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

    [SerializeField]
    Score score;

    Vector3 LastPosition;

    float timer;
    int sensTimer = 1;
    float force;

    public Vector3 positionDeDepart;

    public void ResetPositionAuDernierTir()
    {
        transform.position = LastPosition;
        rigidBodyDeLaBalle.velocity = Vector3.zero;
    }
    public void ResetPositionAuDebutDuLevel()
    {
        transform.position = positionDeDepart;
        rigidBodyDeLaBalle.velocity = Vector3.zero;
    }

    public AudioClip Son;

    private void OnCollisionEnter(Collision collision)
    {
        AudioSource.PlayClipAtPoint(Son, gameObject.transform.position);
    }

    void Start()
    {
        mainCamera = Camera.main;
        rigidBodyDeLaBalle = GetComponent<Rigidbody>();
        positionDeDepart = transform.position;
        Invoke("FirstCam", 0.2f);
    }

    [SerializeField]
    CamEffect lvl1;
    public void FirstCam()
    {
        lvl1.ShowEffect();
    }
    public bool canShoot;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!canShoot)
            return;

        //QUAND LA BALLE EST PRESQUE A L'ARRET (<= Mini)
        if (rigidBodyDeLaBalle.velocity.magnitude <= Mini)
        {
            //J'AFFICHE LA FLECHE DE DIRECTION
            AfficherDirectionFleche();

            //JE STOPPE LA BALLE POUR DE VRAI
            rigidBodyDeLaBalle.velocity = Vector3.zero;

          

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
                LastPosition = transform.position;
                 timer = tempsPourChargerAuMin;
                 Vector3 directionBalle = GetVecteurDirectionBalle();
                //ON ENVOIE LA BALLE
                 rigidBodyDeLaBalle.AddForce(directionBalle * force, ForceMode.Impulse);
                force = 0f;

                score.Shoot();

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
