using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowsShatter : MonoBehaviour
{
    public GameObject BrokenWindow;
    public int ShatterPreasure = 2;

    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag == "Player" || col.gameObject.tag == "ballEnemy" || col.gameObject.tag == "Bullet") && col.relativeVelocity.magnitude > ShatterPreasure)
        {
            Instantiate(BrokenWindow, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

