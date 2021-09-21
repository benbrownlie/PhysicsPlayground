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
    public bool canShoot3 = false;
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
                //Sets the orb type at the index of 0 to active and able to fire
                playerOrbs[0].SetActive(true);
                canShoot1 = true;

                //Sets the other orb types to in-active and unable to fire
                playerOrbs[1].SetActive(false);
                playerOrbs[2].SetActive(false);
                canShoot2 = false;
                canShoot3 = false;
            }

            if (Input.GetMouseButtonDown(0) && desiredPoint.CompareTag("Arsenal1"))
            {
                //Sets the orb type at the index of 1 to active and able to fire
                playerOrbs[1].SetActive(true);
                canShoot2 = true;

                //Sets the other orb types to in-active and unable to fire
                playerOrbs[0].SetActive(false);
                playerOrbs[2].SetActive(false);
                canShoot1 = false;
                canShoot3 = false;
            }

            if (Input.GetMouseButtonDown(0) && desiredPoint.CompareTag("Arsenal2"))
            {
                //Sets the orb type at the index of 2 to active and able to fire
                playerOrbs[2].SetActive(true);
                canShoot3 = true;

                //Sets the other orb types to in-active and unable to fire
                playerOrbs[0].SetActive(false);
                playerOrbs[1].SetActive(false);
                canShoot1 = false;
                canShoot2 = false;
            }

            if (Input.GetMouseButton(0) && desiredPoint.CompareTag("Button"))
            {
                desiredPoint.gameObject.SetActive(false);
            }

            //Checks for the correct mouse input, that the player isn't in the air, and that they can fire on a specific cylinder
            if (Input.GetMouseButtonDown(0) && user.isGrounded && canShoot1)
            {
                //Fires the projectile using the ammo type passed in
                launcher.LaunchProjectile(ammoTypes[0]);
            }

            if (Input.GetMouseButtonDown(0) && user.isGrounded && canShoot2)
            {
                //Fires the projectile using the ammo type passed in
                launcher.LaunchProjectile(ammoTypes[1]);
            }

            if (Input.GetMouseButtonDown(0) && user.isGrounded && canShoot3)
            {
                //Fires the projectile using the ammo type passed in
                launcher.LaunchProjectile(ammoTypes[2]);
            }
        }
    }
}
