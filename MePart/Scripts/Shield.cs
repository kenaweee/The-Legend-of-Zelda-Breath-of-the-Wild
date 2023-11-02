using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    Animator anim;
    public bool canshield = true;
    //public float shielduptime = 10f;
    //public float shieldcooldown = 5f;
    public GameObject sword;
    float starttime;
    float endtime;
   public float time;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) &&!Input.GetKeyDown(KeyCode.LeftShift) && sword.active==true)
        {
            if (canshield)
            {
                shield();

            }
        }
        if(Input.GetKeyUp(KeyCode.Mouse0) && sword.active == true)
        {
            time = -1;
            anim.SetInteger("timer", 0);
          //  flag = true;
        }

    }
    void shield()
    {
        //anim.SetInteger("timer", 10);
        //starttime = Time.time;
        //while (Input.GetKey(KeyCode.Mouse0))
        //{
        //    if(Time.time - starttime == 10)
        //    {
        //        anim.SetInteger("timer", 0);
        //        StartCoroutine(resetshield());
        //        break;
        //    }
        //}
        time = 10;
        StartCoroutine(shieldup());
        
    }
    IEnumerator resetshield()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("fecd");
        canshield = true;

    }
    IEnumerator shieldup()
    {
        anim.SetInteger("timer", 10);
        // flag = false;
        //   yield return new WaitForSeconds(10f);
        // //  if (!flag) {
        //       anim.SetInteger("timer", 0);
        //       canshield = false;
        ////   }

        while (time > 0)
        {
            yield return new WaitForSeconds(1f);
            time -= 1;
        }
        if (time == 0)
        {
            anim.SetInteger("timer", 0);
            canshield = false;
            StartCoroutine(resetshield());
        }
    }
}
