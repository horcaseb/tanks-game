using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorretaA : MonoBehaviour {

    Transform mtransform;
    public GameObject shellclon;
    Transform mRef;
    AudioSource mAudio;
    float tiempo;
    public float velatack;
    public int condisparos=0;
    public int cantidad;
    // Use this for initialization
    void Start()
    {
        mtransform = GetComponent<Transform>();
        //shellclon = GameObject.Find("Shell");
        mRef = mtransform.Find("canion").GetComponent<Transform>();
        mAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RotarT();
        Disparo();
    }
    public void RotarT()
    {
        float magAng = 100;
        Vector3 dirAng = mtransform.up;
        float senX = Input.GetAxis("TorretaA");
        Vector3 velX = magAng * dirAng * senX;
        Vector3 desplazamientoX = velX * Time.deltaTime;// movimiento seguido
        mtransform.eulerAngles += desplazamientoX;
    }
    public float magFuerza;

    public void Disparo()
    {
        if (condisparos <= cantidad)
        {
            tiempo += Time.deltaTime;
            if (Input.GetButtonDown("FireA") && tiempo > 1f / velatack)//condicion de disparo rapido
            {
                condisparos++;
                tiempo = 0;
                GameObject clon = Instantiate(shellclon, mRef.position, mtransform.rotation);
                Rigidbody clonRi = clon.GetComponent<Rigidbody>();//clonar componente rggiboddy

                Vector3 dir = mtransform.forward;//bala salga en el z local
                float sent = 1;//para que salga al lado positivo del eje 
                Vector3 fuerza = magFuerza * dir * sent;
                clonRi.AddForce(fuerza);//al riggi e le ejerce la fuerza
                mAudio.Play();//sonido
                cantidad--;
            }
        }
    }
}
