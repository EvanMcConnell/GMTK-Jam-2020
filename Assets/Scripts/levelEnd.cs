using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEnd : MonoBehaviour
{
    [SerializeField]
    GameObject transitionImage;
    AudioSource endSound;

    [SerializeField]
    string nextLevel;

    public int lc;
    public static int levelCount;

    void Start()
    {
        endSound = GetComponent<AudioSource>();
        levelCount = lc;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            endSound.Play();
            if (GameObject.Find("Coin") == null)
            {
                print("coin collected");
                GameManager.gameManager.addScore();
            }

            print("pref: " + PlayerPrefs.GetInt("level_number"));

            if (levelCount > PlayerPrefs.GetInt("level_number"))
            {
                GameManager.gameManager.increaseLevel();
            }

            transitionImage.GetComponent<transitionManager>().setNextLevel(nextLevel);
            transitionImage.GetComponent<transitionManager>().setState(transitionManager.state.fadeIn);

            print("End");
        }
    }
}
