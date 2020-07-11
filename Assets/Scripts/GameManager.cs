using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int bulletsLeft = 5, levelNumber, score;
    [SerializeField]
    Text bulletUI;
    public static GameManager gameManager;

    private void Awake()
    {
        if (gameManager)
        {
            gameManager.bulletUI = bulletUI;
            if (levelNumber > 0)
            {
                bulletUI.text = bulletsLeft.ToString();
            }
            Destroy(this);
        }
        else
        {
            score = 0;
            if (levelNumber > 0)
            {
                bulletUI.text = bulletsLeft.ToString();
            }
            gameManager = this;
            DontDestroyOnLoad(this);
        }
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

}
