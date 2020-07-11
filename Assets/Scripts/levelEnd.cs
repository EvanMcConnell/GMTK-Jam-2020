using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEnd : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (GameObject.Find("Coin") == null)
            {
                print("coin collected");

            }
            else
            {
                print("coin not collected");
            }

            print("End");
        }
    }
}
