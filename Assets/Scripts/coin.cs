using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    AudioSource chompSound;
    public GameObject soundObject;
    void Update()
    {
        transform.Rotate(50 * Time.deltaTime, 50 * Time.deltaTime, 50 * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(soundObject, new Vector3(0, 0, 0), Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
