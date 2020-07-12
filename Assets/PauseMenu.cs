using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool paused = false;
    
    public GameObject pauseMenu;
    public GameObject main;
    public GameObject quitMenu;

    /*void Start()
    {
        pauseMenu = GameObject.Find("Pause Menu");
        quitMenu = GameObject.Find("Quit Menu");
    }*/


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
        }

        if (paused)
        {
            PlayerPrefs.SetInt("paused", 1);
            Time.timeScale = 0;
            if (pauseMenu.activeInHierarchy == false)
            {
                pauseMenu.SetActive(true);
            }
        }
        else
        {
            PlayerPrefs.SetInt("paused", 0);
            Time.timeScale = 1;
            quitMenu.SetActive(false);
            main.SetActive(true);
            if (pauseMenu.activeInHierarchy == true)
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
        Time.timeScale = 1;
        main.SetActive(false);
        quitMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void noPlsGoBack(){
        Time.timeScale = 1;
        main.SetActive(true);
        quitMenu.SetActive(false);
        Time.timeScale = 0;
    }
}
