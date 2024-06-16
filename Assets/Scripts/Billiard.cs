using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billiard : MonoBehaviour
{
    [SerializeField] private int power;
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.left * power, ForceMode.Impulse);
    }
}
