using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShootBehavior : MonoBehaviour
{
    public ProjectileLauncher launcher;
    public PlayerBehavior user;
    public GameObject playerOrbs;
    public bool canShoot = false;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Transform desiredPoint = hit.transform;

            if (Input.GetMouseButtonDown(0) && desiredPoint.CompareTag("Arsenal"))
            {
                playerOrbs.SetActive(true);
                canShoot = true;
            }

            if (Input.GetMouseButtonDown(0) && user.isGrounded && canShoot)
            {
                launcher.LaunchProjectile();
            }
        }
    }
}
