using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Grenade : MonoBehaviour
{
   public float delay = 3;

   private float countdown;
   public GameObject explosion;

   public float radius = 5;

   public float exposionForce = 70;

   private bool exploeed = false;
    void Start()
    {
        countdown = delay;
    }

    
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <=0 && exploeed ==false)
        {
            Explode();
            exploeed = true;
        }
    }


    private void Explode()
    {

        Instantiate(explosion, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        
        if(colliders.Length > 0)
        {
            foreach (var collider in colliders)
                    {
                        Rigidbody rb = collider.GetComponent<Rigidbody>();
            
                        if (rb !=null)
                        {
                            rb.AddExplosionForce(exposionForce*10, transform.position, radius);
                        }
                    }
              Destroy(gameObject);
        }

        
        
       
    }
}
