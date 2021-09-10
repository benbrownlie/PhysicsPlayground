using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShootBehavior : MonoBehaviour
{
    public ProjectileLauncher launcher;

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Transform desiredPoint = hit.transform;

            if (desiredPoint.CompareTag("Breakable") && Input.GetMouseButtonDown(0))
            {
                launcher.LaunchProjectile();
            }
        }
    }
}
