using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textvidas : MonoBehaviour {
    public ControljugadorA ControljugadorA;
    public ControljugadorR ControljugadorR;
    public TorretaA torretA;
    public TorretaR torretaR;

    public Text vidaA;
    public Text vidaR;
    public Text balaA;
    public Text balaR;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        vidaAA();
        vidaRR();
        balaAA();
        balaRR();

    }
    public void vidaAA()
    {
        vidaA.text = "VIDA= " + ControljugadorA.salud.ToString();
    }

    public void vidaRR()
    {
        vidaR.text = "VIDA= " + ControljugadorR.salud.ToString();
    }

    public void balaAA()
    {
        balaA.text = "Balas= " + torretA.cantidad .ToString();
    }
    public void balaRR()
    {
        balaR.text = "Balas= " + torretaR.cantidad.ToString();
    }
}
