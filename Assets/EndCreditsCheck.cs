using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCreditsCheck : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(GameObject.Find("Player (1)").transform.position.x, transform.position.y, transform.position.z);
    }
}
