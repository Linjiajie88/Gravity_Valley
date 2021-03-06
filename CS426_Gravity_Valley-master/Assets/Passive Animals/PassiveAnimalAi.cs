﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveAnimalAi : MonoBehaviour
{
    // Where is the player
    private Transform playerTransform;

    // FSM related variables
    private Animator animator;
    bool runningAway = false;
    bool waiting = false;
    private float distanceFromTarget;
    public bool inVision;

    // Where is it going and how fast?
    Vector3 direction;
    private float walkSpeed = 2f;
    private int currentTarget;
    private Transform[] waypoints = null;

    private void Awake()
    {
        // Get a reference to the player's transform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        // Get a reference to the FSM (animator)
        animator = gameObject.GetComponent<Animator>();

        // Add all our waypoints into the waypoints array
        Transform point1 = GameObject.Find("p1").transform;
        Transform point2 = GameObject.Find("p2").transform;
        Transform point3 = GameObject.Find("p3").transform;
        
        waypoints = new Transform[3] {
            point1,
            point2,
            point3
        };

    }


    // Update is called once per frame
    void Update()
    {
        // If chasing get the position of the player and point towards it
        if (runningAway)
        {
            direction = playerTransform.position - transform.position;
            rotateAnimal();
        }

        // Unless the zombie is waiting then move
        if (!waiting)
        {
            transform.Translate(walkSpeed * direction * Time.deltaTime, Space.World);
        }
    }

    private void FixedUpdate()
    {
        // Give the values to the FSM (animator)
        distanceFromTarget = Vector3.Distance(waypoints[currentTarget].position, transform.position);
        animator.SetFloat("distanceFromWaypoint", distanceFromTarget);
        animator.SetBool("playerInSight", inVision);

    }

    public void SetNextPoint()
    {
        // Pick a random waypoint 
        // But make sure it is not the same as the last one
        int nextPoint = -1;

        do
        {
            nextPoint = Random.Range(0, waypoints.Length - 1);
        }
        while (nextPoint == currentTarget);

        currentTarget = nextPoint;

        // Load the direction of the next waypoint
        direction = waypoints[currentTarget].position - transform.position;
        rotateAnimal();
    }

    public void Chase()
    {
        // Load the direction of the player
        direction = playerTransform.position - transform.position;
        rotateAnimal();
    }

    public void StopChasing()
    {
        runningAway = false;
    }

    private void rotateAnimal()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        //
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        direction = direction.normalized;
    }

    public void StartChasing()
    {
        runningAway = true;
    }


    public void ToggleWaiting()
    {
        waiting = !waiting;
    }

}
