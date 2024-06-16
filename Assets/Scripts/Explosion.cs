using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private int power;
    private List<Rigidbody> inTriggerZone;

    private void Start()
    {
        inTriggerZone = new List<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            inTriggerZone.Add(other.attachedRigidbody);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            inTriggerZone.Remove(other.attachedRigidbody);
        }
    }

    public void Boom()
    {
        foreach (Rigidbody rg in inTriggerZone)
        {
            float distance = Vector3.Distance(rg.transform.position, transform.position);
            rg.AddForce((rg.transform.position - transform.position).normalized * (1 / distance) * power, ForceMode.Impulse);
        }
    }
}
