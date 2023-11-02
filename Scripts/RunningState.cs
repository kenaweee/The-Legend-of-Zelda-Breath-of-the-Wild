using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunningState : StateMachineBehaviour
{
    //float timer;
    NavMeshAgent agent;
    Transform trees;
    //List<Transform> treePoints = new List<Transform>();


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        trees = GameObject.FindGameObjectWithTag("Tree").transform;
        agent.speed = 1.5f;
        //GameObject go = GameObject.FindGameObjectWithTag("TreePoints");
        //foreach (Transform t in go.transform)
        //    treePoints.Add(t);
        //agent.SetDestination(treePoints[Random.Range(0, treePoints.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if (agent.remainingDistance <= agent.stoppingDistance)
        //    agent.SetDestination(treePoints[Random.Range(0, treePoints.Count)].position);
        //for (int i = 0; i < treePoints.Count; i++)
        //{
        //    float distance = Vector3.Distance(treePoints[i].position, animator.transform.position);
        //    Debug.Log(distance);
        //    if (distance < 10)
        //        animator.SetBool("isPickingUp", true);

        //}
        agent.SetDestination(trees.position);
        float distance = Vector3.Distance(trees.position, animator.transform.position);
       // Debug.Log(distance);
        //Debug.Log("dist"+distance);
        //if (distance > 20)
        //animator.SetBool("isChasing", false);
        if (distance < 3)
            
            animator.SetBool("isPickingUp", true);
      



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
