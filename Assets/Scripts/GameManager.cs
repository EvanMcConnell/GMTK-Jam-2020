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
    bool playing = false;
    [SerializeField]
    Text bulletUI;
    public static GameManager gameManager;
    [SerializeField]
    bool debug;

    private void Awake()
    {
        if (gameManager)
        {
            gameManager.bulletUI = bulletUI;
            print("heyyyy it's me mr gameManager");
            if (gameManager.playing)
            {
                bulletUI.text = bulletsLeft.ToString();
            }
            else
            {
                for (int i = 0; i < levelsCompleted + 1; i++)
                {
                    if (i < 6)
                    {
                        GameObject.Find("Level Locker").GetComponent<levelStorage>().levels[i].SetActive(true);
                    }
                }
            }
            saveGame();
            Destroy(this);
        }
        else
        {
            print("Where the fuck am I!!????");
            //if (!debug) { gameManager = this; loadGame(); }
            if (playing)
            {
                bulletUI.text = bulletsLeft.ToString();
            }
            else
            {
                for (int i = 0; i < levelsCompleted + 1; i++)
                {
                    if (i < 6)
                    {
                        GameObject.Find("Level Locker").GetComponent<levelStorage>().levels[i].SetActive(true);
                    }
                }
            }
            gameManager = this;
            loadGame();
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void loadLevel(string level)
    {
        if (!playing)
        {
            playing = true;
            score = 0;
            bulletsLeft = 5;
        }
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
