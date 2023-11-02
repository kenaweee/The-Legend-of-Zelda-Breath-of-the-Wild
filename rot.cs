using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot : MonoBehaviour
{
    public Vector3 RotateAmount;
    public bool cuberot = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cuberot==false)
        {
            transform.Rotate(RotateAmount * Time.deltaTime);
        }
        else
        {

        }
    }
}
