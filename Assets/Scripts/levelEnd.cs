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
    public static bool endCredits = false;

    void Start()
    {
        endSound = GetComponent<AudioSource>();
        levelCount = lc;
        endCredits = false;
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

            if (nextLevel != "Main Menu")
            {
                transitionImage.GetComponent<transitionManager>().setNextLevel(nextLevel);
                transitionImage.GetComponent<transitionManager>().setState(transitionManager.state.fadeIn);
            }
            else
            {
                //GameManager.gameManager.loadMainMenu();
                GameObject.Find("Player (1)").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                GameObject.Find("Player (1)").GetComponent<characterController>().enabled = false;
                GameObject.Find("Player (1)").transform.parent = gameObject.transform;
                GameObject.Find("Player (1)").transform.localPosition = new Vector3(0, 0, GameObject.Find("Player (1)").transform.localPosition.z);
                
                GameObject.Find("Main Camera").transform.parent = gameObject.transform;
                GameObject.Find("Main Camera").transform.localPosition = new Vector3(0, GameObject.Find("Main Camera").transform.localPosition.y, GameObject.Find("Main Camera").transform.localPosition.z);
                StartCoroutine(gameEnd());
            }

            print("End");
        }
    }

    IEnumerator gameEnd()
    {
        //GameObject.Find("Player (1)").transform.position = Vector3.MoveTowards(GameObject.Find("Player (1)").transform.position, transform.position, 10);
        yield return new WaitForSecondsRealtime(7);
        GameManager.gameManager.loadMainMenu();
    }
}
