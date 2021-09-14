using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehavior : MonoBehaviour
{
    public Vector3 rotation;

    void Update()
    {
        gameObject.transform.Rotate(rotation);
    }
}
