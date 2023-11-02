using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockmoving : MonoBehaviour
{
    public int speed;
    public bool isFreezing;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveBlock();
        
    }
    void MoveBlock()
    {
        if (isFreezing == false)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
