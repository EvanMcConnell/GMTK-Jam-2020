using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPrefab;
    GameObject player;
    public float thrust = 1.0f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("spawn", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        let dir = player.transform.position - transform.position;
        dir = dir.normalized;
        rb.AddForce(dir * thrust);
    }

    void spawn()
    {
        Instantiate(myPrefab, transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);

    }
}
