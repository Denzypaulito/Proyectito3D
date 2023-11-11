using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public GameObject vehiculo;
    Rigidbody[] rigidBodies;
    Animator animator;
    public bool golpe;
    public AILocomotion AILocomotion;

    UnityEngine.AI.NavMeshAgent navMeshAgent;

    void Start()
    {
        rigidBodies = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        DeactivateRagdoll();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vehiculo")
        {
            vehiculo = other.gameObject;
            golpe = true;
            AILocomotion.enabled = false;
            navMeshAgent.enabled = false;
            ActivateRagdoll();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Vehiculo")
        {
            vehiculo = other.gameObject;
            golpe = false;
        }
    }

    public void DeactivateRagdoll()
    {
        foreach (var rigidBody in rigidBodies)
        {
            rigidBody.isKinematic = true;
        }
        animator.enabled = true;
    }

    public void ActivateRagdoll()
    {
        foreach (var rigidBody in rigidBodies)
        {
            rigidBody.isKinematic = false;
        }
        animator.enabled = false;
    }
}