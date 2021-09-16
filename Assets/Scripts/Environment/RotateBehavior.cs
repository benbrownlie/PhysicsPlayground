using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehavior : MonoBehaviour
{
    //Variable that will dictate the speed at which the object rotates
    public Vector3 rotation;

    void Update()
    {
        //Continually rotates an object based off the past in value
        gameObject.transform.Rotate(rotation);
    }
}
