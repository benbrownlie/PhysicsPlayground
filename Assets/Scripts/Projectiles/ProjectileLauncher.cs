using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    private Transform _target;
    public Rigidbody projectile;

    public float projectileTime = 2.0f;

    private Vector3 _displacement = new Vector3();
    private Vector3 _acceleration = new Vector3();
    private float _time = 0.0f;
    private Vector3 _initialVelocity = new Vector3();
    private Vector3 _finalVelocity = new Vector3();

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    LaunchProjectile(projectile);
        //}
    }

    public void LaunchProjectile(Rigidbody projectile)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray, out hit);

        _displacement = hit.point - transform.position;
        _acceleration = Physics.gravity;
        _time = projectileTime;
        _initialVelocity = FindInitialVelocity(_displacement, _acceleration, _time);
        _finalVelocity = FindFinalVelocity(_initialVelocity, _acceleration, _time);

        Rigidbody projectileInstance = Instantiate(projectile, transform.position, transform.rotation);
        projectileInstance.velocity = _initialVelocity;
    }

    private Vector3 FindFinalVelocity(Vector3 initialVelocity, Vector3 acceleration, float time)
    {
        //v = v0 + at
        Vector3 finalVelocity;

        finalVelocity = initialVelocity + acceleration * time;

        return finalVelocity;
    }

    private Vector3 FindDisplacement(Vector3 initialVelocity, Vector3 acceleration, float time)
    {
        //deltaX = v0*t + (1/2)*a*t^2
        Vector3 displacement = initialVelocity * time + (1 / 2) * acceleration * time * time;

        return displacement;
    }

    private Vector3 FindInitialVelocity(Vector3 displacement, Vector3 acceleration, float time)
    {
        //deltaX = v0*t + (1/2)*a*t^2
        //deltaX - (1/2)*a*t^2 = v0*t
        //deltaX/t - (1/2)*a*t = v0
        //v0 = deltaX/t - (1/2)*a*t
        Vector3 initialVelocity = displacement / time - 0.5f * acceleration * time;

        return initialVelocity;
    }
}
