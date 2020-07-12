using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool paused = false;
    GameObject pauseMenu;

    void Start()
    {
        pauseMenu = GameObject.Find("Pause Menu");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (paused)
        {
            Time.timeScale = 0;
            if(pauseMenu.activeInHierarchy == false)
            {
                pauseMenu.SetActive(true);
            }
        }
        else
        {
            Time.timeScale = 1;
            if(pauseMenu.activeInHierarchy == true)
            {
                pauseMenu.SetActive(false);
            }
        }
    }

    public void resume()
    {
        paused = false;
    }

    public void quit()
    {

    }
}
