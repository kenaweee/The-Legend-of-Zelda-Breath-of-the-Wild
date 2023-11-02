using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigflameball : MonoBehaviour
{
    private bool flag = false;
    // Start is called before the first frame update
    private void Start()
    {
        Destroy(gameObject, 10);
        flag = true;
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {

            if(flag == true)
            {
                other.GetComponent<healthplayer>().TakeDamage(4);
                flag = false;
            }
            
        }

    }
}
