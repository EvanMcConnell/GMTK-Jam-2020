using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    AudioSource chompSound;

    private void Start()
    {
        chompSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        transform.Rotate(50 * Time.deltaTime, 50 * Time.deltaTime, 50 * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            chompSound.Play();
            Destroy(gameObject);
        }
    }
}
