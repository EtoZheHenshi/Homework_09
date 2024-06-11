using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private Collider explosionArea;
    private void Start()
    {
        explosionArea = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(
            (other.transform.position - transform.position).normalized * (30 / Vector3.Distance(other.transform.position, transform.position)),
            ForceMode.Impulse);
    }
}
