using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonGravity : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            other.attachedRigidbody.useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            other.attachedRigidbody.useGravity = true;
        }
    }
}
