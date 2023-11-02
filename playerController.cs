using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
     public int Hp = 24;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fireball"))
        {
            Hp -= 2;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("bigfireball"))
        {
            Hp -= 5;
            Destroy(other.gameObject);
        }
    }
}
