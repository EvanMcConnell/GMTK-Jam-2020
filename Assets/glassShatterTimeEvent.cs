using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassShatterTimeEvent : MonoBehaviour
{
    public GameObject BrokenWindow;
    public float timeBreak = 15;
    void Start()
    {
        StartCoroutine(shatterGlass());
    }


    IEnumerator shatterGlass()
    {
        yield return new WaitForSeconds(timeBreak);
        Instantiate(BrokenWindow, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
