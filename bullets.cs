using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{
    TorretaA torretaA;
    TorretaR torretaR;
    Collider coli;
    MeshRenderer ren;
    public int X;
    // Use this for initialization
    void Start() {
        coli = GetComponent<Collider>();
        ren = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update() { }

    void OnCollisionEnter(Collision golpe)
    {
        GameObject objetocolisionado = golpe.gameObject;
        if (golpe.gameObject.tag == "PlayerA" )
        {
            torretaA = objetocolisionado.GetComponentInChildren<TorretaA>();
            torretaA.cantidad -= X;
            Destroy(gameObject);
        }
        if (golpe.gameObject.tag == "PlayerR" )
        {
            torretaR = objetocolisionado.GetComponentInChildren<TorretaR>();
            torretaR.cantidad -= X;
            Destroy(gameObject);
        }
    }
}
