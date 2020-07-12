using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class restartScene : MonoBehaviour
{
    public GameObject Resety;
    GameObject[] allEnemies;
    int EnemyAmount;


    void Start()
    {
        Resety.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void doTheThing()
    {
        StartCoroutine(resetShow());
    }


    IEnumerator resetShow()
    {
        yield return new WaitForSeconds(10);
        Resety.SetActive(true);
    }
}
