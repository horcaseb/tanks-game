using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vida : MonoBehaviour {
    ControljugadorA ControljugadorA;
    ControljugadorR ControljugadorR;
    public int X;//cantidad de vida que le vamos a dar
    BoxCollider coli;//moneda
    MeshRenderer ren;

    // Use this for initialization
    void Start () {
        coli = GetComponent<BoxCollider>();
        ren = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update () {}

    void OnCollisionEnter(Collision golpe)
    {
        GameObject objetocolisionado = golpe.gameObject;

        if (golpe.gameObject.tag == "PlayerA" )
        {
            ControljugadorA = objetocolisionado.GetComponent<ControljugadorA>();
            ControljugadorA.Destruir(-X);//la cantidad que le sube el cosito de la monedita
            Destroy(gameObject);//destruye la moneda

            if (ControljugadorA.salud > 100)
            {
                ControljugadorA.salud = 100;
                Destroy(gameObject);
            }
        }
        if (golpe.gameObject.tag == "PlayerR")
        {
            ControljugadorR = objetocolisionado.GetComponent<ControljugadorR>();
            ControljugadorR.Destruir(-X);
            Destroy(gameObject);

            if (ControljugadorR.salud > 100)
            {
                ControljugadorR.salud = 100;
                Destroy(gameObject);
            }
        }
    }
}
