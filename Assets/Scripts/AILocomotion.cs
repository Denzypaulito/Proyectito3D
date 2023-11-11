using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AILocomotion : MonoBehaviour
{
    public Transform playerTransform;
    public float maxTime = 1.0f;
    public float maxDistance = 1.0f;
    public Vector3 areaCenter; // Centro del área permitida
    public Vector2 areaSize = new Vector2(10.0f, 5.0f); // Tamaño del área permitida (ancho, largo)
    public float minTimeBetweenTp = 5.0f;
    public float maxTimeBetweenTp = 15.0f;
    public float timeTp = 0.0f;
    NavMeshAgent agent;
    Animator animator;
    float timer = 0.0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        SetRandomDestination();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timeTp -= Time.deltaTime;

        if (timer < 0.0f)
        {
            float sqDistance = (playerTransform.position - agent.destination).sqrMagnitude;
            if (sqDistance > maxDistance)
            {
                SetRandomDestination();
            }
            timer = maxTime;
        }

        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    void OnDrawGizmosSelected()
    {
        // Dibujar el área permitida (rectángulo)
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(areaCenter, new Vector3(areaSize.x, 0.0f, areaSize.y));

        // Dibujar el rango de movimiento aleatorio (círculo)
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, areaSize.x);
    }

    void SetRandomDestination()
    {
        float randomTimeBetweenTp = Random.Range(minTimeBetweenTp, maxTimeBetweenTp);
        if (timeTp < 0.0f)
        {
            float randomX = Random.Range(-areaSize.x / 2.0f, areaSize.x / 2.0f);
            float randomZ = Random.Range(-areaSize.y / 2.0f, areaSize.y / 2.0f);

            Vector3 randomDirection = areaCenter + new Vector3(randomX, 0.0f, randomZ);
            
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, Mathf.Max(areaSize.x, areaSize.y), 1);
            agent.SetDestination(hit.position);
            timeTp = randomTimeBetweenTp;
        }
    }
}
