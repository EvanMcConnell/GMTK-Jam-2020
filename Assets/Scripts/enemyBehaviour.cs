using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPrefab;
    void Start()
    {
        InvokeRepeating("LaunchProjectile", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LaunchProjectile()
    {
        Instantiate(myPrefab, transform.position + new Vector3(0.5f, 2, 0), Quaternion.identity);

    }
}
