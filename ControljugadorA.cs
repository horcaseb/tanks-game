using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControljugadorA : MonoBehaviour {
    public Text rojo;
    public int salud ;
    FireA fuego;
    

    // Use this for initialization
    void Start() {
        fuego = GetComponentInChildren<FireA>();//Buscar dentro de los componentes del tanque algo llamado FireA
    }

    // Update is called once per frame
    void Update() {
    }
    public void Destruir( int _cantidad)//cantidad que se baja, cuando se llama en otra clase se indica la cantidad que se baja
    {
        salud -= _cantidad;
        if (_cantidad > 0)
        {
            fuego.Activar();
        }
        if (salud <= 0)
        {
            rojo.color = new Color(0.8f,0,0,1);
            Destroy(gameObject);
        }
    }
    
}
