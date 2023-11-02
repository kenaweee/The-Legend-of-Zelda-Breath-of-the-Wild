using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class enemy1trial : MonoBehaviour
{
    public NavMeshAgent myAgent;
    public Transform myPlayer;
    bool followPlayer = true;
    Animator animator;
    public PlayerRuneAbility2 playerRef;
    public bool isfreezing;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        animator= GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (followPlayer)
        {
            myAgent.SetDestination(myPlayer.position);

        }
       
    }
    

                 

       
    }

