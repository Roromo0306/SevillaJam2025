using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemigo_Tanque : MonoBehaviour
{
    public float vida = 10f;
    private float damage = 3f;
    GameObject jugador, enemigo;

    //Perseguir
    private float distM = 4;
    private float velocidad = 1.5f;
    private Rigidbody rb;
    void Start()
    {
        enemigo = this.gameObject;
        jugador = GameObject.Find("jugador");
    }

    
    void Update()
    {
        if(vida<= 0)
        {
            Destroy(enemigo);
        }
        float dist = Vector3.Distance(jugador.transform.position, enemigo.transform.position);
        if (dist < distM)
        {
            perseguir();
        }
        Debug.Log("La vida del enemigo es " + vida);
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
        Jugador Jscript = jugador.GetComponent<Jugador>();
        if (Jscript != null)
        {
            Jscript.RecibirDaño(damage);
        }
    }
}
