using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShootBehavior : MonoBehaviour
{
    public ProjectileLauncher launcher;
    public PlayerBehavior user;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Transform desiredPoint = hit.transform;

            if (Input.GetMouseButtonDown(0) && user.isGrounded == true)
            {
                launcher.LaunchProjectile();
            }
        }
    }
}
