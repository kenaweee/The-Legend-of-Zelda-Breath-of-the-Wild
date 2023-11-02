using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    

    private void Start(){
        Destroy(gameObject,10);
    }
    private void OnTriggerEnter(Collider other){
       // Debug.Log("alooooo");
        Destroy(transform.GetComponent<Rigidbody>());
        if (other.tag == "Bokoblin")
        {
            Debug.Log("khabat");
             transform.parent = other.transform;
            other.GetComponent<Enemy>().TakeDamage(5);
        }
        if (other.tag == "boss1")
        {
            Debug.Log("khabat");
            transform.parent = other.transform;
            other.GetComponent<FireBlightController>().TakeDamage(5);
        }
        if (other.tag == "Hinox1")
        {
            Debug.Log("khabat");
            transform.parent = other.transform;
            other.GetComponent<Hinox>().TakeDamage(5);
        }
        if (other.tag == "Hinox2")
        {
            Debug.Log("khabat");
            transform.parent = other.transform;
            other.GetComponent<healthhino>().TakeDamage(5);
        }

    }
}
