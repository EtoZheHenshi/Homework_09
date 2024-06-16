using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Superman : MonoBehaviour
{
    [SerializeField] int flySpeed;
    [SerializeField] int impactForce;
    private CharacterBody body;
    private Rigidbody rg;
    private CharacterBody target;
    private bool haveTarget;

    private void Start()
    {
        body = GetComponent<CharacterBody>();
        rg = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!haveTarget)
        {
            target = FindFirstObjectByType<CharacterBody>();
            if (target != null && target.gameObject.layer != LayerMask.NameToLayer("Superman"))
            {
                MoveToTarget();
            }
        }

        if (target == null)
        {
            haveTarget = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            collision.rigidbody.AddForce((collision.transform.position - transform.position).normalized * impactForce, ForceMode.VelocityChange);
            Destroy(collision.gameObject, 1.5f);
            AfterHit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject, 1f);
        Invoke("AfterHit", 0.5f);
    }

    private void AfterHit()
    {
        rg.velocity = Vector3.zero;
        rg.angularVelocity = Vector3.zero;
        ChangeState(0, -90f);
    }

    private void MoveToTarget()
    {
        haveTarget = true;
        ChangeState(180f, 0);
        transform.LookAt(target.transform);
        rg.AddForce((target.Body.transform.position - transform.position).normalized * flySpeed, ForceMode.Acceleration);
    }

    private void ChangeState(float handRotationX, float bodyRotationX)
    {
        body.LeftHand.transform.rotation = Quaternion.Euler(handRotationX, 0, 0);
        body.RightHand.transform.rotation = Quaternion.Euler(handRotationX, 0, 0);
        transform.rotation = Quaternion.Euler(bodyRotationX, 0, 0);
    }
}
