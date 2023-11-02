using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.HID;



public class mariamrunes : MonoBehaviour
{
   // public block2moving reference1;
    //public ChaseState enemyRef;
    public GameObject rotating;

    Vector3 posup;
    Vector3 posfinal;
    public GameObject Cube;
    bool freeze = false;
    bool ice = false;
    bool ability3 = false;
    bool ability4 = false;
   // public NavMeshAgent agent;
    //public Animator agents;
  //  public Transform agenttransform;

    Camera cam;
    void Start()
    {

        cam = Camera.main;


    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ability4 = true;
            Debug.Log(ability4);
            ability3 = false;
            if (ice == true)
            {
                GameObject[] allObjects = GameObject.FindGameObjectsWithTag("cube");
                foreach (GameObject obj in allObjects)
                {
                    Destroy(obj);
                }

                ice = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            rotating.GetComponent<rot>().cuberot = false;
            ability3 = true;
            ability4 = false;
            if (freeze == true)
            {
               
                freeze = false;
            }

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (ability4 == true)
            {
                freeze = true;
                Freeze3();
                StartCoroutine(Freeze3());
            }
            if (ability3 == true)
            {
                ice = true;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Ocean")

                    {


                        Instantiate(Cube, hit.point, Quaternion.identity);


                    }
                }
            }

        }
    }


    bool trial = true;
    IEnumerator Freeze3()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Bokoblin")

            {

                if (trial)
                {
                    if (rotating.GetComponent<rot>() != null)
                    {

                        rotating.GetComponent<rot>().cuberot = true;

                    }

                    //agenttransform.position.x = 0;
                    yield return new WaitForSeconds(10);
                    rotating.GetComponent<rot>().cuberot = false;


                    
                    trial = true;
                }




            }
        }
    }
}







// if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out RaycastHit hitInfo, 200f))
//{
//  if(hitInfo.collider.tag == "myPlayer")
//{

//}
//Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 200f, Color.black);
//   Debug.Log("I jest hit smth");
//}
// else
//{
//  Debug.Log("nothing");
//}
//myAgent.SetDestination(myPlayer.position);

//if (Vector3.Distance(transform.position, target1.position) < 1)
//{
//  myAgent.SetDestination(target2.position);
//}
//else if (Vector3.Distance(transform.position, target2.position) < 1)
//{
//  myAgent.SetDestination(target1.position);
//}
//if (Input.GetKeyDown(KeyCode.Space))
//{
//  followPlayer = true;