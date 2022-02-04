using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireA : MonoBehaviour {
    MotorA miMotor;
    ParticleSystem ps;
    float tiempo;
    bool activado = false;
	// Use this for initialization
	void Start ()
    {
        ps = GetComponent<ParticleSystem>();
        miMotor = GetComponentInParent<MotorA>();
	}

    public void Activar() {
        ps.Play();
        activado = true;
    }

	// Update is called once per frame
	void Update ()
    {
        if (activado) {
            Daño();
        }
    }
    public void Daño()
    {
        tiempo += Time.deltaTime;

        if (tiempo < 10)
        {
            miMotor.mag = 4;
        }
        else
        {
            miMotor.mag = 8;
            ps.Stop();
            activado = false;
        }
    }
}
