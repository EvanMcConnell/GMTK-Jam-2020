using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject player;
    public int maxEnemies = 20;
    GameObject[] allEnemies;
    int EnemyAmount;
    public float thrust = 1.0f;
    Rigidbody2D rb;
    Vector2 m_NewPosition;
    Renderer renderer;
    void Start()
    {
        player = GameObject.FindWithTag("player");
        rb = GetComponent<Rigidbody2D>();
        renderer = gameObject.GetComponent<Renderer>();

        //set color
        renderer.material.SetColor("_Color", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));

        //force indirection of player on spawn
        rb.AddForce((player.transform.position - transform.position).normalized * thrust * Time.smoothDeltaTime);

        allEnemies = GameObject.FindGameObjectsWithTag("ballEnemy");
        EnemyAmount = allEnemies.Length;
        print("enemyAmount: " + EnemyAmount);

        //start spawn
        InvokeRepeating("spawn", 2.0f, 2.0f);
    }

    void spawn()
    {
        rb.AddForce((player.transform.position - transform.position + new Vector3(0, 1, 0)).normalized * thrust * Time.smoothDeltaTime);
        print("enemyAmount: " + EnemyAmount);
        print("maxEnemies: " + maxEnemies);

        allEnemies = GameObject.FindGameObjectsWithTag("ballEnemy");
        EnemyAmount = allEnemies.Length;

        if (EnemyAmount < maxEnemies)
        {
            Instantiate(myPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
