using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{

    private Color[] colors = new Color[] { Color.green, Color.red, Color.blue };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Renderer>().material.color = colors[0];
        Debug.Log("Verde");
    }

    private void OnTriggerStay(Collider other)
    {
        GetComponent<Renderer>().material.color = colors[1];
        Debug.Log("Rojo");
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Renderer>().material.color = colors[2];
        Debug.Log("Azul");
    }
    /* private void OnCollisionEnter(Collision collision)
     {
         GetComponent<Renderer>().material.color = colors[0];
         Debug.Log("Verde");
     }

     private void OnCollisionStay(Collision collision)
     {
         GetComponent<Renderer>().material.color = colors[1];
         Debug.Log("Rojo");
     }

     private void OnCollisionExit(Collision collision)
     {
         GetComponent<Renderer>().material.color = colors[2];
         Debug.Log("Azul");
     }*/
}
