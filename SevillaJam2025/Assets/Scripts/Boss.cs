using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Boss : MonoBehaviour
{

    private float damage = 3.5f;
    private GameObject jugador, enemigo;

    //Perseguir
    private float distM = 20f;
    private float velocidad = 1f;
    private float desaceleracion = 0.1f;
    private Rigidbody rb;

    private Vector3 dirc;
    private bool perse = true;
    private bool salt = false;

    private float tiemEn = 3f;
    private float tiempRes = 30f;
    private float tiemEn2 = 2f;
    private float tiempRes2;

    private int tiempoEspera=5;

    void Start()
    {
        enemigo = this.gameObject;
        jugador = GameObject.Find("Player");
        tiempRes = tiemEn;
        
    }


    void Update()
    {
        if (VidaEnemigos.Vida_Normal <= 0)
        {
            Destroy(enemigo);
        }

        tiempRes =  tiempRes - 5* Time.deltaTime;
        if ( tiempRes <= 0)
        {
            perse = false;
            StartCoroutine(Para());
            

            if (velocidad < 0)
            {
                Debug.Log("Velocidad 0");
                velocidad = 0;
                salt = true;
            }


            tiempRes = tiemEn;
            
        }

        float dist = Vector3.Distance(jugador.transform.position, enemigo.transform.position);
        if (dist < distM)
        {
            if (perse == true) 
            { 
            perseguir();
            }
        }
        // Debug.Log("La vida del enemigo es " + VidaEnemigos.Vida_Normal);
        dirc = enemigo.transform.position;
        if(salt == true)
        {
            saltar();
            salt = false;
        }
        

    }

    private void saltar()
    {
        Debug.Log("La posición en el eje y" + dirc.y);
        dirc.y += 2;
        enemigo.transform.position = dirc;

    }

    public IEnumerator Para()
    {
        if (velocidad > 0)
        {
            Debug.Log("Desacelerando");
            while (velocidad >= 0)
            {
                velocidad -= desaceleracion * Time.deltaTime;
                Debug.Log("La velocidad es " + velocidad);
            }

        }
        Debug.Log("gogo");
        yield return new WaitForSeconds(tiempoEspera);
    }

    private void perseguir()
    {
        enemigo.transform.LookAt(jugador.transform.position);
        transform.position = Vector3.MoveTowards(enemigo.transform.position, jugador.transform.position, velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject jugadorC = collision.gameObject;

        if (jugadorC.tag == "Player")
        {
            ataque(jugador);
        }
    }

    void ataque(GameObject jugador)
    {
        Player Jscript = jugador.GetComponent<Player>();
        if (Jscript != null)
        {
            Jscript.RecibirDaño(damage);
        }
    }
}