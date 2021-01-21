using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BunnyAI : MonoBehaviour
{
    private Transform target;
    private float timer = 8;
    private float radius = 50;
    private float idleTimer = 5;

    private NavMeshAgent agent;
    private float currentTimer;
    private float cIdleTimer;


    static Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentTimer = timer;
        cIdleTimer = idleTimer;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer += Time.deltaTime;
        cIdleTimer += Time.deltaTime;

        if(cIdleTimer >= idleTimer)
        {
            agent.velocity = Vector3.zero;
            StartCoroutine("switchMove");
            
        }

        if(currentTimer >= timer)
        {
            Vector3 newPosition = RandNavSphere(transform.position, radius, -1);
            agent.SetDestination(newPosition);
            //anim.SetBool("IsMoving", true);
            currentTimer = 0;
        }
    }

    IEnumerator switchMove()
    {
        anim.SetBool("IsMoving", false);
        yield return new WaitForSeconds(3);
        cIdleTimer = 0;
        anim.SetBool("IsMoving", true);
    }

    public static Vector3 RandNavSphere(Vector3 origin, float dist, int layerMask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * dist;
        randomDirection += origin;
        
        NavMeshHit navMeshHit;
        NavMesh.SamplePosition(randomDirection, out navMeshHit, dist, layerMask);

        return navMeshHit.position;

    }
}
