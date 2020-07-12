using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int bulletsLeft = 5, levelsCompleted, score;
    [SerializeField]
    bool playing;
    [SerializeField]
    Text bulletUI;
    public static GameManager gameManager;

    private void Awake()
    {
        if (gameManager)
        {
            gameManager.bulletUI = bulletUI;
            if (playing)
            {
                bulletUI.text = bulletsLeft.ToString();
            }
            else
            {

            }
            saveGame();
            Destroy(this);
        }
        else
        {
            if (playing)
            {
                bulletUI.text = bulletsLeft.ToString();
            }
            else
            {

            }
            gameManager = this;
            loadGame();
            DontDestroyOnLoad(this);
        }
    }

    public void loadLevel(string level)
    {
        playing = true;
        SceneManager.LoadScene(level);
    }

    public void loadMainMenu()
    {
        playing = false;
        SceneManager.LoadScene("Main Menu");
    }



    public bool canShoot()
    {
        if (bulletsLeft > 0)
        {
            bulletsLeft--;
            if (bulletsLeft > 0)
                bulletUI.text = bulletsLeft.ToString();
            else
                bulletUI.text = "NO";

            print(bulletsLeft + " bullets remaining");
            return true;
        }
        else return false;
    }


    public void addScore()
    {
        score++;
    }

    public void saveGame()
    {
        PlayerPrefs.SetInt("level_number", levelsCompleted);
    }

    public void loadGame()
    {
        gameManager.score = 0;
        gameManager.levelsCompleted = PlayerPrefs.GetInt("level_number");
    }

}
