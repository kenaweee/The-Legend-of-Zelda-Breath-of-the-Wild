using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoblinChaseState : StateMachineBehaviour
{
    public NavMeshAgent agent;
    Transform player;
    bool flag = false;
    //public GameObject theplayer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = 0.6f;
        flag = true;
    }
       
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > 15)
            animator.SetBool("isChasing", false);


        if (distance < 1.5f)
        {
            Debug.Log("attacking");
            animator.SetBool("isChasing", false);

            animator.SetBool("isAttacking", true);
            Collider[] colliders = Physics.OverlapSphere(player.position, 2.0f);
            foreach (Collider hit in colliders)
            {

                if (hit.GetComponent<healthplayer>() != null && flag == true)
                {

                    hit.GetComponent<healthplayer>().TakeDamage(2);
                    flag = false;

                }
            }
            //  if (flag == true)
            //{
            //  animator.SetBool("isAttacking", true);
            //flag = false;
            //}
            //else
            //{
            //  animator.SetBool("verticalAttack", true);
            // flag = true;
            // }

            //theplayer.GetComponent<healthplayer>().TakeDamage(1);



        }


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
