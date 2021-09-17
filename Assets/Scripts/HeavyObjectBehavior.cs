using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyObjectBehavior : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Explosive"))
        {
            _rigidbody.isKinematic = false;
        }
    }
}
