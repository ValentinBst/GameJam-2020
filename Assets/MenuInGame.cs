using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInGame : MonoBehaviour
{
    Canvas c;
    [SerializeField]
    Balle b;
    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<Canvas>();
        ShowMenu();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!c.enabled)
                ShowMenu();
            else
                HideMenu();
        }
    }

    public void ShowMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        c.enabled = true;
        b.canShoot = false;
        Time.timeScale = 0;
    }
    public void HideMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        c.enabled = false;
        b.canShoot = true;
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
