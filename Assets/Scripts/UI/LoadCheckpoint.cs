using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCheckpoint : MonoBehaviour
{
    [SerializeField]
    private PlayerBehavior _player;

    public void Checkpoint()
    {
        _player.transform.position = _player.checkpoint;
    }
}
