using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ragdoll : MonoBehaviour
{
    public GameObject vehiculo;
    Rigidbody[] rigidBodies;
    Animator animator;
    public bool golpe;
    public AILocomotion AILocomotion;

    public GameObject prop;
    UnityEngine.AI.NavMeshAgent navMeshAgent;

    [SerializeField] private float cantidadPuntos;

    [SerializeField] private Contador menu;

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
            Invoke("EliminarObject", 3.0f);
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
        menu.SumPoints(cantidadPuntos);
        menu.SumDeaths(1.0f);
        foreach (var rigidBody in rigidBodies)
        {
            rigidBody.isKinematic = false;
            
        }
        animator.enabled = false;
    }
    void EliminarObject()
    {
        if (prop != null)
    {
        Destroy(prop);
    }
    }
}
