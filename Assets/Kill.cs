using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Balle balle = GetComponent<Balle>();
            balle.ResetPositionAuDebutDuLevel();
        }
    }
}
