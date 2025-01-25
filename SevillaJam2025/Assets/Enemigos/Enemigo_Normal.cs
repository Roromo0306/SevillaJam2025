using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemigo_Normal : MonoBehaviour
{
    
    private float damage = 2f;
    GameObject jugador, enemigo;

    //Perseguir
    private float distM = 4;
    private float velocidad = 3f;
    private Rigidbody rb;
    void Start()
    {
        enemigo = this.gameObject;
        jugador = GameObject.Find("jugador");
    }

    
    void Update()
    {
        if (VidaEnemigos.Vida_Normal <= 0)
        {
            Destroy(enemigo);
        }

        float dist = Vector3.Distance(jugador.transform.position, enemigo.transform.position);
        if (dist < distM)
        {
            perseguir();
        }
        Debug.Log("La vida del enemigo es " + VidaEnemigos.Vida_Normal);

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
