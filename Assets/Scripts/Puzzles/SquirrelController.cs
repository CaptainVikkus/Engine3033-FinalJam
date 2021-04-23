using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SquirrelController : MonoBehaviour
{
    [SerializeField] Transform nestLocation;
    [SerializeField] float arrivalThreshold = 0.5f;

    Transform target; 

    Transform startLocation;
    NavMeshAgent agent;
    Animator animator;

    private static readonly int MovingHash = Animator.StringToHash("Moving");

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        startLocation = transform;
    }

    private void OnSeasonChange(int season)
    {
        if (season == (int)Season.Winter)
            MoveToNest();
        else if (Vector3.Distance(nestLocation.position, transform.position) <= arrivalThreshold)
            MoveToStart();
    }
    
    private void MoveToNest()
    {
        animator.SetBool(MovingHash, true);
        agent.SetDestination(nestLocation.position);

        target = nestLocation;

        InvokeRepeating(nameof(CheckArrival), 0.5f, 0.1f);
    }
    private void MoveToStart()
    {
        animator.SetBool(MovingHash, true);
        agent.SetDestination(startLocation.position);

        target = startLocation;

        InvokeRepeating(nameof(CheckArrival), 0.5f, 0.1f);
    }

    private void CheckArrival()
    {
        if (Vector3.Distance(target.position, transform.position) >= arrivalThreshold)
            return; //Not Arrived

        animator.SetBool(MovingHash, false);
        transform.rotation = target.rotation;
        CancelInvoke(nameof(CheckArrival));
    }

    private void OnEnable()
    {
        PlayerEvents.SeasonChanged += OnSeasonChange;
    }

    private void OnDisable()
    {
        PlayerEvents.SeasonChanged -= OnSeasonChange;
    }

}
