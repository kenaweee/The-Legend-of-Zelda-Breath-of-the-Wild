using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Climb : MonoBehaviour
{
    [Header("Refernces")]
    public Transform oriantaion;
    //public Rigidbody rb;
    public LayerMask whatiswall;
    //  public ThirdPersonController tpr;
    public LayerMask thecube;

    Animator anim;

    [Header("Climbing")]
    public float climbspeed;
    public float boxclimbspeed;
    public bool climbing;
    public bool boxclimbing;

    [Header("Deatection ")]
    public float detectionlength;
    public float spherecastradius;

    private RaycastHit frontwallhit;
    //private RaycastHit thecube;
    private bool wallfront;
    private bool cubefront;
    Ray edge;
    //public ThirdPersonController th;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
       // transform.position = transform.position + new Vector3(0, 1 * Time.deltaTime, 0);

        edge = new Ray(transform.position, Vector3.left); 
        wallcheck();
        boxcheck();
        //edgedetect();
        StateMachine();
        if (climbing) climbingMovment();
        if(boxclimbing) cubeMovment();
        //while (Physics.Raycast(edge, out edgehit)){
        //    if (edgehit.collider.tag == "edge")
        //    {
        //        anim.SetTrigger("l");
        //    }
        //}
    }
    private void StateMachine()
    {
        if (wallfront && Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!climbing)
            {
                startclimbing();
            } }
        if (cubefront && Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!boxclimbing)
            {
                startboxclimbing();
            }
        }
        
        //edgedetect();
        //if (edgefront)
        //{
        //    Debug.Log("H");
        //    anim.SetTrigger("l");
        //}
        //if(edgefront && Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    anim.SetTrigger("l");
        //}
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
                stopclimbing();
            
  
        }
    }
    private void wallcheck()
    {
        wallfront = Physics.SphereCast(transform.position, spherecastradius, oriantaion.forward, out frontwallhit, detectionlength, whatiswall);

    }
    private void boxcheck()
    {
        cubefront = Physics.SphereCast(transform.position, spherecastradius, oriantaion.forward, out frontwallhit, detectionlength, thecube);

    }
    //private void edgedetect()
    //{
    //    edgefront = Physics.SphereCast(transform.position, spherecastradius, oriantaion.forward, out edgehit, detectionlength, whatisegde);
    //    if (edgehit.collider.tag=="edge")
    //    {
    //        anim.SetTrigger("l");
    //    }
    //}
    private void startclimbing()
    {
        climbing = true;
    }
    private void startboxclimbing()
    {
        
   
        boxclimbing = true;
    }
    private void climbingMovment()
    {
        anim.SetBool("climb", true);
        //transform.position = transform.position + new Vector3(0, climbspeed * Time.deltaTime, 0);
        StartCoroutine(climbs());


        //  transform.position += Vector3.up * climbspeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(0, climbspeed * Time.deltaTime, -1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(0, climbspeed * Time.deltaTime, 1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)&&!wallfront)
        {
            transform.position = transform.position + new Vector3(-1, 0, 0);
        }
        if (boxclimbing && !wallfront)
        {
            transform.position = transform.position + new Vector3(-1, 0, 0);
            stopclimbing();
        }
        //if(Physics.Raycast(edge, out edgehit))
        //{
        //    if (edgehit.collider.tag == "edge")
        //    {
        //        anim.SetTrigger("l");
        //    }
        //}
        //{
        //    Debug.Log("H");
        //    anim.SetTrigger("l");
        //}
        //{
        //    //lanid
        //    Debug.Log("H");
        //    anim.SetTrigger("l");
        //}
        //if (!wallfront)
        //{
        //    anim.SetTrigger("l");
        //}
    }
    private void cubeMovment()
    {
        anim.SetBool("climb", true);
        transform.position = transform.position + new Vector3(0, boxclimbspeed * Time.deltaTime, 0);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(0,  0, -1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(0,0, 1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !wallfront)
        {
            transform.position = transform.position + new Vector3(-1, 0, 0);
        }
        if (boxclimbing && !cubefront)
        {
           // transform.position = transform.position + new Vector3(1, 0, 0);

           // anim.SetBool("Grounded", true);
            stopboxclimbing();
        }
        //if(Physics.Raycast(edge, out edgehit))
        //{
        //    if (edgehit.collider.tag == "edge")
        //    {
        //        anim.SetTrigger("l");
        //    }
        //}
        //{
        //    Debug.Log("H");
        //    anim.SetTrigger("l");
        //}
        //{
        //    //lanid
        //    Debug.Log("H");
        //    anim.SetTrigger("l");
        //}
        //if (!wallfront)
        //{
        //    anim.SetTrigger("l");
        //}
    }

    private void stopclimbing()
    {
       // transform.position = transform.position + new Vector3(0, 1 * climbspeed * Time.deltaTime, 0);
        climbing = false;
        anim.SetBool("climb", false);
    }
    private void stopboxclimbing()
    {
        // transform.position = transform.position + new Vector3(0, 1 * climbspeed * Time.deltaTime, 0);
        boxclimbing = false;
        anim.SetBool("climb", false);
    }
    IEnumerator climbs()
    {
        while (climbing)
        {
            transform.position = transform.position + new Vector3(0, climbspeed * Time.deltaTime, 0);
            anim.SetBool("FreeFall", false);
            yield return new WaitForSeconds(9.0f);
        }
    }

}
