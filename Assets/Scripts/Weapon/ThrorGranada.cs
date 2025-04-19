using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrorGranada : MonoBehaviour
{
    public float throwForce = 500;
    public GameObject grenadePreaf;
  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Throw();
        }
    }


    public void Throw()
    {
        GameObject newGranada = Instantiate(grenadePreaf, transform.position, transform.rotation);
        newGranada.GetComponent<Rigidbody>().AddForce(transform.forward*throwForce);
    }
}
