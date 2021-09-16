using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShootBehavior : MonoBehaviour
{
    public ProjectileLauncher launcher;
    public PlayerBehavior user;
    public GameObject[] playerOrbs;
    public bool canShoot1 = false;
    public bool canShoot2 = false;
    public Rigidbody[] ammoTypes;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Transform desiredPoint = hit.transform;

            if (Input.GetMouseButtonDown(0) && desiredPoint.CompareTag("Arsenal"))
            {
                playerOrbs[0].SetActive(true);
                canShoot1 = true;
            }

            if (Input.GetMouseButtonDown(0) && desiredPoint.CompareTag("Arsenal1"))
            {
                playerOrbs[1].SetActive(true);
                canShoot2 = true;
            }

            if (Input.GetMouseButtonDown(0) && user.isGrounded && canShoot1)
            {
                launcher.LaunchProjectile(ammoTypes[0]);
            }

            if (Input.GetMouseButtonDown(1) && user.isGrounded && canShoot2)
            {
                launcher.LaunchProjectile(ammoTypes[1]);
            }
        }
    }
}
