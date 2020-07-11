using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField]
    GameObject particle;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(particle, Camera.main.ScreenPointToRay(Input.mousePosition).origin, transform.rotation);
        }
    }
}
