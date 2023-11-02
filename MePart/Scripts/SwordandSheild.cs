using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//using UnityEngine.InputSystem.XR;

public class SwordandSheild : MonoBehaviour
{
    public GameObject sword;
    Animator anim;
    public bool swording = false;
    // public Climb c;
    private CharacterController _controller;
    Vector3 velocityy;

    void Start()
    {
        anim = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !Input.GetKeyDown(KeyCode.LeftShift) && sword.active == true)
        {
            //  Debug.Log(c.climbing);

            anim.SetTrigger("sword");
            // //anim.SetInteger("Speed", 0);
            //// anim.SetBool("slash2",true);
            swording = true;
            damage(sword);
            StartCoroutine(waittt());
            //  sword();
            // 

        }





    }
    //void sword()
    //{
    //    anim.SetTrigger("sword");
    //    swording = true;

    //    StartCoroutine(waittt());

    //}
    void damage(GameObject sword)
    {
        Vector3 swordpos = sword.transform.position;
        Collider[] colliders = Physics.OverlapSphere(swordpos, 1f);
        foreach (Collider hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null && swording)
            {

                hit.GetComponent<Enemy>().TakeDamage(10);

            }
            if (hit.GetComponent<FireBlightController>() != null && swording)
            {

                hit.GetComponent<FireBlightController>().TakeDamage(10);

            }
            if (hit.GetComponent<Hinox>() != null && swording)
            {

                hit.GetComponent<Hinox>().TakeDamage(10);

            }
            if (hit.GetComponent<healthhino>() != null && swording)
            {

                hit.GetComponent<healthhino>().TakeDamage(10);

            }

        }

    }

    IEnumerator waittt()
    {
        yield return new WaitForSeconds(1f);
        swording = false;
        anim.ResetTrigger("sword");
        //   anim.SetBool("slash2", false);

    }
}