using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float distance;
    private Transform target;
    NavMeshAgent agent;
    Animator anim;
    public Enemy dusman;
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(dusman.isDead == false)
        {
            anim.SetFloat("Velocity", agent.velocity.magnitude);
            distance = Vector3.Distance(transform.position, target.transform.position);
            if(distance <= 15)
            {
                agent.enabled = true;
                agent.destination = target.position;
            }
            else
            {
                agent.enabled = false;
            }
            if(distance <= 1.2)
            {
                agent.enabled = false;
            }
            if(dusman.isDead == true)
            {
                agent.enabled = false;
            }
        }
    }
}
