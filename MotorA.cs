using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorA : MonoBehaviour {


    Transform mtransform;//posicion del tanque
    AudioSource mvolume;//volumen del audio del tanque
    Rigidbody mcuerpo;//rigibody del tanque
    bool suelo;//toca o no toca piso
    float tiempo=0;//contador tiempo del salto

    public float mag = 8;//velocidad tanque


    void Start ()
    {
        mtransform= GetComponent< Transform >();
        mvolume = GetComponent<AudioSource>();
        mcuerpo = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        salto();
        movrot();
    }

    public void movrot()
    {
        //desplazamiento de frente
        Vector3 dirZ = mtransform.forward;//direccion en Z
        float senZ = Input.GetAxis("VerticalA");//teclas de arriba y abajo
        Vector3 velZ = mag * dirZ * senZ;//velocidad del tanque
        Vector3 desplazamientoZ = (velZ) * Time.deltaTime;//desplazamiento en el tiempo
        mtransform.position += desplazamientoZ;//movimiento definitivo

        //rotacion lados       
        float magAng = 60;//velocidad a los lados
        Vector3 dirAng = new Vector3(0, 1, 0);//rota en el eje y como tuerquita
        float senAng = Input.GetAxis("HorizontalA");//tecla de los lados
        Vector3 velAng = magAng * dirAng * senAng;
        Vector3 desplazamientoAng = (velAng) * Time.deltaTime;
        mtransform.eulerAngles += desplazamientoAng;//Como se llama la rotacion

        if (senZ == 0 && senAng == 0)//condicion de audio 
        {
            mvolume.volume = 0;//baja vovolumen a 0
        }
        else
            mvolume.volume = 1;//sube volumen a 1
    }
    private void OnCollisionEnter(Collision collision)//colisiin del piso
    {
        if (collision.gameObject.tag == "suelo")
        {
            suelo = true;//positivo para saltar
        }
    }
    public void salto()
    {
        //salto parabolico (y,z)
        float magy = 100;
        float magz = 500;
        float sen = 1;
        Vector3 diry = mtransform.up;//donde estoy parado mi eje y o y local 
        Vector3 dirz = mtransform.forward;// z local 
        Vector3 fuerza = magy * diry * sen ;
        Vector3 fuerza2 = magz * dirz * sen;

        if (Input.GetButtonDown("JumpA") && suelo /*&& tiempo==0*/)//condiciones de salto
        {
            mcuerpo.AddForce(fuerza+fuerza2);
            suelo = false;
            //tiempo += Time.deltaTime;
        }
        /*if (tiempo == 5)
        {
            tiempo = 0;
        }*/

    }
}
