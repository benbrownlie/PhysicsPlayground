using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentEvent : MonoBehaviour
{
    public GameObject triggerObject;
    public GameObject eventObject;

    private void FixedUpdate()
    {
        if (triggerObject.active == false)
        {
            eventObject.SetActive(true);
        }
    }
}
