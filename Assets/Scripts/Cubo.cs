using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{
    public int x, y, z;

    void Start()
    {
        //Para optimizar las figuras 
        if (Physics.Raycast(transform.position, transform.up)){
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
        }
    }

    void Update()
    {

    }
}
