using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowsShatter : MonoBehaviour
{
    public GameObject BrokenWindow;
    public float ShatterPreasure = 2f;

    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Player" || col.gameObject.tag == "ballEnemy" || col.gameObject.tag == "Bullet") && col.relativeVelocity.magnitude > ShatterPreasure)
        {
            Instantiate(BrokenWindow, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

a