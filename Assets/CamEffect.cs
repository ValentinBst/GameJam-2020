using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamEffect : MonoBehaviour
{
    [SerializeField]
    GameObject cam;

    public void ShowEffect()
    {
        cam.SetActive(true);
        FindObjectOfType<Balle>().canShoot = false;
        Invoke("DisableCam", 6f);
    }

    void DisableCam()
    {
        cam.SetActive(false);
        Invoke("ActivePlayer", 5f);
    }

    void ActivePlayer()
    {
        FindObjectOfType<Balle>().canShoot = true;
    }
}
