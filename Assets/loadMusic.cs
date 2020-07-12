using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadMusic : MonoBehaviour
{
    public GameObject music;
    void Start()
    {
        if (GameObject.Find("gameMusic(Clone)") == null)
        {
            Instantiate(music, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

}
