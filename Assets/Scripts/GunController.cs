using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField]
    GameObject bullet, bulletPivot;
    [SerializeField]
    float bulletSpeed=1;
    Vector3 mousePos;

    // Update is called once per frame

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        rotateWeapon();
        checkForFire();
    }

    void rotateWeapon()
    {
        mousePos = new Vector3(Camera.main.ScreenPointToRay(Input.mousePosition).origin.x, Camera.main.ScreenPointToRay(Input.mousePosition).origin.y, 0);

        transform.LookAt(mousePos);
        if (transform.position.x > mousePos.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.x+ 180);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, transform.rotation.eulerAngles.x+180);

        }
    }


    void checkForFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bullet != null)
            {
                if (Vector3.Distance(mousePos, transform.position) > 1)
                {
                    if (gameManager.canShoot())
                    {
                        GameObject projectile = Instantiate(bullet, bulletPivot.transform.position, Quaternion.identity);
                        if (projectile.tag == "Bullet")
                        {
                            projectile.GetComponent<Bullet>().setSpeed(bulletSpeed);
                        }
                        projectile.transform.LookAt(mousePos);
                        if (transform.position.x > mousePos.x)
                        {
                            projectile.transform.rotation = Quaternion.Euler(0, 0, projectile.transform.rotation.eulerAngles.x + 180);
                        }
                        else
                        {
                            projectile.transform.rotation = Quaternion.Euler(0, 180, projectile.transform.rotation.eulerAngles.x + 180);

                        }
                    }
                }
            }
        }
    }

}



