using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP = 20;
    public Animator animator;
    public AudioSource enemydie;
    public AudioSource footsteps;
    public AudioSource punching;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    public void TakeDamage(int damageAmount)
    {
        Debug.Log(HP);
        HP -= damageAmount;
        if (HP <= 0)
        {
            enemydie.Play();
            animator.SetTrigger("die");
            Destroy(gameObject, 3);
           // GetComponent<Collider>().enabled = false;
        }
        else
        {
            animator.SetTrigger("damage");

        }

    }
}
