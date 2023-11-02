using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

using System.Net.NetworkInformation;


using UnityEngine.AI;
using UnityEngine.InputSystem.HID;


public class ThrowingTutorial : MonoBehaviour
{
    public TMP_Text RuneAbility;

    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]
   
    public float throwCooldown;

    [Header("Throwing")]
    
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    [Header("thebombing")]
    
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upforce = 1.0f;
    bool throwed = false;
    bool holding = false;

    bool bombed = false;
    
     GameObject proj;
    public GameObject fakebomb;

    private block2moving reference1;
    private ChaseState enemyRef;

    Vector3 posup;
    Vector3 posfinal;
    public GameObject Cube;
    bool freeze = false;
    bool ice = false;
    bool ability3 = false;
    bool ability4 = false;
    private NavMeshAgent agent;
    private Animator agents;
    private Transform agenttransform;

    Camera cam2;
    public GameObject shrinecube;

   public GameObject playerarm;



    private void Start()
    {
        cam2 = Camera.main;
        readyToThrow = true;

    }

    
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Alpha1) &throwed ==false && readyToThrow)
        {
            RuneAbility.text = "Rune Ability: Remote Bomb";
            ability3 = false;
            ability4 = false;
            
            if (freeze == true)
            {
                agent.isStopped = false;
                freeze = false;
                if(agents != null)
                {
                    agents.SetBool("freeze", false);
                }
                if(shrinecube!= null)
                {
                    shrinecube.GetComponent<rot>().cuberot = false;
                    
                }
            }
            if (ice == true)
            {
                GameObject[] allObjects = GameObject.FindGameObjectsWithTag("cube");
                foreach (GameObject obj in allObjects)
                {
                    Destroy(obj);
                }

                ice = false;
            }

            if (holding == false)
            {
                fakebomb.SetActive(true);
                holding = true;
            }
            else
            {
                fakebomb.SetActive(false);
                holding = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.Q) & holding == true & throwed==false)
        {
            

            proj = Throw();
            



        }
        if (Input.GetKeyDown(KeyCode.Q) && throwed == true && bombed == false)
        {
            throwed = false;
            Detonate(proj);
            bombed = true;
           
        }

        // MIRO

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            RuneAbility.text = "Rune Ability: Statis";
            ability4 = true;
            Debug.Log(ability4);
            ability3 = false;
            fakebomb.SetActive(false);
            holding = false;
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
            RuneAbility.text = "Rune Ability: Cryonis"; 
            ability3 = true;
            ability4 = false;
            fakebomb.SetActive(false);
            holding = false;
            if (freeze == true)
            {
                if(agent !=null)
                agent.isStopped = false;
                freeze = false;
                if (agents != null)
                {
                    agents.SetBool("freeze", false);
                }

                if (shrinecube != null)
                {
                    shrinecube.GetComponent<rot>().cuberot = false;

                }
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
                Ray ray = cam2.ScreenPointToRay(Input.mousePosition);
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
    void Detonate(GameObject projectile)
    {
        Vector3 explosionPosition = projectile.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (hit.GetComponent<Enemy>() != null)
            {

                hit.GetComponent<Enemy>().TakeDamage(10);

            }
            if(hit.GetComponent<FireBlightController>() != null)
            {
                hit.GetComponent<FireBlightController>().TakeDamage(10);
                
            }
            if (hit.GetComponent<healthhino>() != null)
            {
                hit.GetComponent<healthhino>().TakeDamage(10);

            }
            if (hit.GetComponent<Hinox>() != null)
            {
                hit.GetComponent<Hinox>().TakeDamage(10);

            }
           

            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upforce, ForceMode.Impulse);
            }
        }
        Destroy(proj);
        
    }
    //
  

    private GameObject Throw()
    {

        playerarm.GetComponent<Animator>().SetTrigger("throw");
        readyToThrow = false;

        // instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);
        


        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

       

        // implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
        return projectile;
    }

    private void ResetThrow()
    {
        //playerarm.GetComponent<Animator>().SetTrigger("throw");
        readyToThrow = true;
        throwed = true;
        bombed = false;
        

    }

    bool trial = true;
    IEnumerator Freeze3()
    {
        Ray ray = cam2.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Bokoblin")

            {

                if (trial)
                {
                    
                    agents = hit.collider.GetComponent<Animator>();
                    agent = hit.collider.GetComponent<NavMeshAgent>();
                    agents.SetBool("freeze", true);

                    agent.isStopped = true;
                    trial = false;
                    //agenttransform.position.x = 0;
                    yield return new WaitForSeconds(10);
                    agents.SetBool("freeze", false);


                    agent.isStopped = false;
                    trial = true;
                }




            }

            if (hit.collider.tag == "boss1" || hit.collider.tag == "Hinox1" || hit.collider.tag == "Hinox2")

            {

                if (trial)
                {

                    agents = hit.collider.GetComponent<Animator>();
                    agent = hit.collider.GetComponent<NavMeshAgent>();
                    agents.SetBool("freeze", true);

                    agent.isStopped = true;
                    trial = false;
                    //agenttransform.position.x = 0;
                    yield return new WaitForSeconds(10);
                    agents.SetBool("freeze", false);


                    agent.isStopped = false;
                    trial = true;
                }




            }
            if (hit.collider.tag == "shrinecube")

            {

                if (trial)
                {

                   
                        hit.collider.GetComponent<rot>().cuberot = true;
                        yield return new WaitForSeconds(10);
                        hit.collider.GetComponent<rot>().cuberot = false;
                    
                }




            }
        }
    }
}