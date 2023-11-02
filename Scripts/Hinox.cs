using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hinox : MonoBehaviour
{
    public int HP = 150;
    public GameObject phase2;


    void Update()
    {
           if(HP <= 100)
        {
            this.gameObject.SetActive(false);
            phase2.transform.localPosition = this.gameObject.transform.localPosition;
            phase2.SetActive(true);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        Debug.Log("hi111");
        HP -= damageAmount;
        if (HP <= 0)
        {
            //play death animation
        }
        else
        {
            //play hit animation
        }
    }
}
