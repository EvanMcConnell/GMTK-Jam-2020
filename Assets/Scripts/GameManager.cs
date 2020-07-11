using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int bulletsLeft = 5, levelNumber;
    [SerializeField]
    Text bulletUI;

    private void Start()
    {
        if(levelNumber > 0)
        {
            bulletUI.text = bulletsLeft.ToString();
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

}
