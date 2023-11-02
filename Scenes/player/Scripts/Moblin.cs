using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moblin : MonoBehaviour
{
    public int HP = 30;
    public Animator animator;

    public AudioSource deadd;



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
            deadd.Play();
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
