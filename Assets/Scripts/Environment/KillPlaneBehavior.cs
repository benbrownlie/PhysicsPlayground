﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlaneBehavior : MonoBehaviour
{
    public PlayerBehavior player;

    private void OnTriggerEnter(Collider other)
    {
        if (other == player)
        {
            player.transform.position = player.checkpoint.transform.position;
        }
    }
}
