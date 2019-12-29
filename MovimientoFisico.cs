using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFisico : MonoBehaviour
{
    public int score = 0;
    public Rigidbody rb;

    public Camera CamaraUno;
    public Camera CamaraDos;
    public GameObject EsferaMov;
    public GameObject EsferaEst;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        EsferaMov = GameObject.FindGameObjectWithTag("Esfera Aleatoria");
        EsferaEst = GameObject.FindGameObjectWithTag("Esfera Estatica");
        CamaraUno = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
        CamaraDos = GameObject.FindGameObjectWithTag("Camara Secundaria").GetComponent<Camera>() as Camera;

        CamaraUno.enabled = true;
        CamaraDos.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (CamaraUno.enabled == true)
            {
                CamaraDos.enabled = true;
                CamaraUno.enabled = false;
            }
            else if (!CamaraUno.enabled)
            {
                CamaraDos.enabled = false;
                CamaraUno.enabled = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W)) {
            rb.AddForce(Vector3.forward * 1f, ForceMode.Impulse);
            //CamaraUno.transform.Translate(Vector3.forward * 1f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * 1f, ForceMode.Impulse);
            //CamaraUno.transform.Translate(Vector3.left * 1f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * 1f, ForceMode.Impulse);
            //CamaraUno.transform.Translate(Vector3.back * 1f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * 1f, ForceMode.Impulse);
            //CamaraUno.transform.Translate(Vector3.right * 1f * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Esfera Aleatoria")
        {
            score += 10;
        }

        if (collision.gameObject.tag == "Esfera Estatica")
        {
            score += 10;
        }
    }

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 10, 10), "Score = " + score);
        GUILayout.EndArea();
    }
}
