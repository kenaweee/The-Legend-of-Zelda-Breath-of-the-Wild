using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FireBlightController : MonoBehaviour
{
    public GameObject player;
    public GameObject fireball;
    public GameObject bigFireball;
    public GameObject fireField;
    public int health = 200;
    public bool phase = false;
    Animation anim;
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;
    public Slider healthBar;
    private bool dead = false;
    // Start is called before the first
    // frame update
    void Start()
    {


        fireField = this.transform.GetChild(2).gameObject;
        fireField.SetActive(false);
        anim = GetComponent<Animation>();
        agent = GetComponent<NavMeshAgent>();
        GameObject go = GameObject.FindGameObjectWithTag("WayPoints");
        foreach(Transform t in go.transform)
            wayPoints.Add(t);
        StartCoroutine(spawnfireBall());
       
        //StartCoroutine(phase2());


    }

    // Update is called once per frame
    void Update()
    {

        if (!anim.isPlaying & health>0)
        {
            anim.Play("idle");
        }
        if (health <= 0 & dead==false)
        {
            dead = true;
            anim.Play("die");
            agent.isStopped = true;
            Destroy(gameObject, 1);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);

        }
        if(health <= 150 && !phase & health>0)
        {
            phase = true;
            anim.Play("rage");
            fireField.SetActive(true);
            StartCoroutine(phase2());

           
        }

        healthBar.value = health;



    }
    //IEnumerator roam()
    //{
    //    yield return new WaitForSeconds(1);
    //    agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
    //    anim.Play("walk");

    //    roaming = true;
    //}
    IEnumerator phase2()
    {
        if (health > 0)
        {
            anim.Stop();

            agent.isStopped = true;



            fireField.SetActive(false);
            this.GetComponent<CapsuleCollider>().enabled = true;
            GameObject fireBall = Instantiate(bigFireball, this.transform.position + new Vector3(-0.8f, 1.95f, 1.5f), transform.rotation) as GameObject;

            yield return new WaitForSeconds(0.5f);

            anim["hit2"].speed = 0.05f;
            anim.Play("hit2");
            this.transform.LookAt(player.transform);
            yield return new WaitForSeconds(4);
            Rigidbody rb = fireBall.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 10;
            yield return new WaitForSeconds(1);

            fireField.SetActive(true);
            this.GetComponent<CapsuleCollider>().enabled = false;
            anim.Play("walk (1)");



            agent.isStopped = false;

            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
            anim["walk"].speed = 0.75f;

            anim.Play("walk");
            yield return new WaitForSeconds(4);


            StartCoroutine(phase2());
        }
        
    }
    IEnumerator spawnfireBall()
    {
        if (!phase & dead==false)
        {
            anim.Stop();
            agent.isStopped = true;


            transform.LookAt(player.transform);
            anim.Play("walk (1)");

            GameObject fireBall = Instantiate(fireball, this.transform.position + new Vector3(0f, 1.95f, 1.5f), transform.rotation) as GameObject;

            Rigidbody rb = fireBall.GetComponent<Rigidbody>();
            //  fireBall.transform.localScale += new Vector3(-0.75f, -0.75f, -0.75f);
            rb.velocity = transform.forward * 10;
            yield return new WaitForSeconds(1);
            agent.isStopped = false;

            agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
            anim["walk"].speed = 0.75f;

            anim.Play("walk");
            yield return new WaitForSeconds(2);

            StartCoroutine(spawnfireBall());
        }
    }
    public void TakeDamage(int DamageAmount)
    {
        health = health - DamageAmount;
        Debug.Log("i got damaged" + DamageAmount);

    }
}
