using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoILJM : MonoBehaviour
{
    public float rotacion = 100f; // Valor para la rotacion con U y O
    public float velocidad = 10f; // Valor para el movimiento con ILJM
    int colisiones = 0;

    void Start()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }


    void Update()
    {
        Rotate(); //Hacemos el update del metodo Rotate()
        Move(); //Hacemos el update del metodo Move()
    }

    void Rotate() //Metodo que controla la rotación de nuestra esfera cuando pulsamos U o O.
    {
        if (Input.GetKey(KeyCode.U))
            transform.Rotate(new Vector3(0f, -rotacion, 0f) * Time.deltaTime);//Si pulsamos la U rotamos hacia la izquierda
        else if (Input.GetKey(KeyCode.O))
            transform.Rotate(new Vector3(0f, rotacion, 0f) * Time.deltaTime); //Si pulsamos la O rotamos hacia la derecha
    }

    void Move() //Metodo que controla el movimiento de nuestra esfera al pulsar IJLM.
    {
        if (Input.GetKey(KeyCode.I))
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime); //Nos movemos hacia delante
        else if (Input.GetKey(KeyCode.M))
            transform.Translate(Vector3.back * velocidad * Time.deltaTime);//Nos movemos hacia detras
        else if (Input.GetKey(KeyCode.L))
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);//Nos movemos hacia la izquierda
        else if (Input.GetKey(KeyCode.J))
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);//Nos movemos hacia la derecha

    }

    private void OnCollisionEnter(Collision other)
    {
        colisiones += 1;
        Debug.Log("Numero de colisiones" + colisiones);
    }
}
