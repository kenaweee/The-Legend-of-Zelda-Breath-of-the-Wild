using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject thebomb;
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upforce = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(thebomb== enabled)
        {
            Invoke("Detonate", 5);
        }
    }

    void Detonate()
    {
        Vector3 explosionPosition = thebomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upforce, ForceMode.Impulse);
            }
        }
        //DestroyImmediate(thebomb.gameObject,true);

    }
}
