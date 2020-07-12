using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEnd : MonoBehaviour
{
    [SerializeField]
    GameObject transitionImage;
    [SerializeField]
    string nextLevel;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (GameObject.Find("Coin") == null)
            {
                print("coin collected");
                GameManager.gameManager.addScore();
            }

            transitionImage.GetComponent<transitionManager>().setNextLevel(nextLevel);
            transitionImage.GetComponent<transitionManager>().setState(transitionManager.state.fadeIn);

            print("End");
        }
    }
}
