using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentEvent : MonoBehaviour
{
    public GameObject triggerObject;
    public GameObject[] eventObjects;

    private void FixedUpdate()
    {
        if (triggerObject.active == false)
        {
            eventObjects[0].SetActive(true);
            eventObjects[1].SetActive(true);
        }
    }
}
