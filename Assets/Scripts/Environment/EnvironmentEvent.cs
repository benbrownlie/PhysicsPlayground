using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentEvent : MonoBehaviour
{
    //Object that will be used to trigger the event
    public GameObject triggerObject;
    //The event objects that will be used
    public GameObject[] eventObjects;

    private void FixedUpdate()
    {
        //Checks if the trigger is active
        if (triggerObject.active == false)
        {
            //If not, activates the event objects
            eventObjects[0].SetActive(true);
            eventObjects[1].SetActive(true);
        }
    }
}
