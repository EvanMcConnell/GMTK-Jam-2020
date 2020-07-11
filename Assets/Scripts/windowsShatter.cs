using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowsShatter : MonoBehaviour
{
    public GameObject BrokenWindow;

    void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.tag == "player" || col.gameObject.tag == "ballEnemy") && col.relativeVelocity.magnitude > 2)
        {
            Instantiate(BrokenWindow, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

