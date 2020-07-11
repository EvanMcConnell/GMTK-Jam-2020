using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField]
    GameObject bullet, gunPivot;
    [SerializeField]
    float bulletSpeed=1;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = new Vector3(Camera.main.ScreenPointToRay(Input.mousePosition).origin.x, Camera.main.ScreenPointToRay(Input.mousePosition).origin.y,0);

            GameObject projectile = Instantiate(bullet, gunPivot.transform.position, Quaternion.identity);
            projectile.GetComponent<Bullet>().setSpeed(bulletSpeed);
            projectile.transform.LookAt(mousePos);
            if (transform.position.x > mousePos.x)
            {
                projectile.transform.rotation = Quaternion.Euler(180, 180, projectile.transform.rotation.eulerAngles.x);
            }
            else
            {
                projectile.transform.rotation = Quaternion.Euler(180, 0, projectile.transform.rotation.eulerAngles.x);

            }

        }
    }
}



