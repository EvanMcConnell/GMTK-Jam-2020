using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPrefab;
    public GameObject player;
    public float thrust = 1.0f;
    Rigidbody2D rb;
    Vector2 m_NewPosition;
    void Start()
    {
        player = GameObject.FindWithTag("player");
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce((player.transform.position - transform.position).normalized * thrust * Time.smoothDeltaTime);
        InvokeRepeating("spawn", 2.0f, 2.0f);
        var cubeRenderer = gameObject.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
    }

    // Update is called once per frame
    void spawn()
    {
        rb.AddForce((player.transform.position - transform.position).normalized * thrust * Time.smoothDeltaTime);
        Instantiate(myPrefab, transform.position + new Vector3(0, 0, 0), Quaternion.identity);

    }
}
