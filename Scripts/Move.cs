using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [Range(0, 5)]
    public float speed = 1;

    public int health = 20;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0, Input.GetAxis("Vertical") * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Tree")
        {
            Debug.Log("tree hit");
            health=health-4;
        }
        if (other.tag == "foot")
        {
            Debug.Log("foot hit");

            health = health - 2;
        }
    }
}