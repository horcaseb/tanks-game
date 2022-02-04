using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour {
    MeshRenderer objeto;
    BoxCollider caja;
    ParticleSystem ps;
    public GameObject[] objetos;
    public GameObject[] powerups;
    public int vida;
    int contador=0;
    // Use this for initialization
    void Start() {
        objeto = GetComponent < MeshRenderer>();
        caja = GetComponent<BoxCollider>();
        ps = GetComponent<ParticleSystem>();

        int aleatorio = Random.Range(0, objetos.Length);
        try
        {
            Instantiate(objetos[aleatorio], transform.position, Quaternion.identity);
        }
        catch
        {}
    }
    // Update is called once per frame
    void Update()
    {}
    void OnCollisionEnter(Collision golpe)
    {
        contador++;
        if (contador == vida)
        {
            int power = Random.Range(0, 2);
            GameObject objetocolisionado = golpe.gameObject;

            if (golpe.gameObject.tag == "balaA" || golpe.gameObject.tag == "balaR")
            {
                Destroy(gameObject);
                Instantiate(powerups[power], transform.position, Quaternion.identity);
            }
        }
    }
}
