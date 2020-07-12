using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        allEnemies = GameObject.FindGameObjectsWithTag("ballEnemy");
        EnemyAmount = allEnemies.Length;

        if (allEnemies.Length > 0 && EnemyAmount >= allEnemies[0].GetComponent<enemyBehaviour>().maxEnemies)
        {
            StartCoroutine(resetShow());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator resetShow()
    {
        yield return new WaitForSeconds(10);
        Resety.SetActive(true);
    }
}
