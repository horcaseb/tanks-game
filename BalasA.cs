using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalasA : MonoBehaviour {
    ControljugadorR ControljugadorR;
	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	}
    void OnCollisionEnter(Collision golpe)
    {
        GameObject objetocolisionado = golpe.gameObject;//definir que va a hacer el objeto colisionado
        if (golpe.gameObject.tag == "PlayerR")
        {
            ControljugadorR = objetocolisionado.GetComponent<ControljugadorR>();
            ControljugadorR.Destruir(5);
        }
        Destroy(gameObject);
    }
}
