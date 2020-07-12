using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyFunMusic : MonoBehaviour
{
    void Start()
    {
        if (GameObject.Find("gameMusic(Clone)"))
        {
            Destroy(GameObject.Find("gameMusic(Clone)"));
        }
    }


}
