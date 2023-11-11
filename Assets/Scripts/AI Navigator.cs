using UnityEngine;
using UnityEngine.AI;

public class AINavigator : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    Animator anim;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        agent.SetDestination(target.position);
        UpdateAnimations();
    }

    void UpdateAnimations()
    {
        float speed;
        speed = agent.velocity.magnitude;
        speed = Mathf.Clamp01(speed);
        anim.SetFloat("Speed", speed, 0.1f, Time.deltaTime);
    }
}