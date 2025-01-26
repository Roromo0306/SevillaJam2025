using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float damage = 3f;
    public GameObject jugador;

    // Perseguir
    private float distM = 20f;
    private float distN = 4f;
    private float velocidad = 1f;
    private float desaceleracion = 0.1f;
    private Rigidbody rb;

    private bool persiguiendo = true;

    private float tiempoPersecucion = 15f;
    private float tiempoEsperaSalto = 2f;
    private float tiempoEnElAire = 0.5f;

    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("PlayerVerdadero");
        StartCoroutine(PersiguiendoCoroutine());
    }

    void Update()
    {
        // Destruir enemigo si la vida es cero o menor
       

        if (persiguiendo)
        {
            float dist = Vector3.Distance(jugador.transform.position, transform.position);
            if (dist < distM)
            {
                Perseguir();

            }
        }
    }

    private void Perseguir()
    {
        //transform.LookAt(jugador.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, jugador.transform.position, velocidad * Time.deltaTime);
    }

    private IEnumerator PersiguiendoCoroutine()
    {
        // Persigue al jugador durante el tiempo especificado
        yield return new WaitForSeconds(tiempoPersecucion);

        // Parar y saltar
        yield return StartCoroutine(Saltar());

        // Continuar persiguiendo
        persiguiendo = true;
        StartCoroutine(PersiguiendoCoroutine());
    }

    private IEnumerator Saltar()
    {
        // Detenerse y preparar el salto
        persiguiendo = false;
        velocidad = 0f;

        // Saltar
        Vector3 saltoPos = transform.position;
        saltoPos.y += 2; // Altura del salto
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < tiempoEnElAire)
        {
            transform.position = Vector3.Lerp(transform.position, saltoPos, tiempoTranscurrido / tiempoEnElAire);
            tiempoTranscurrido += Time.deltaTime;
            yield return null; // Espera un frame
        }

        // Regresar al suelo
        saltoPos.y -= 2; // Volver a la altura original
        tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < tiempoEnElAire)
        {
            transform.position = Vector3.Lerp(transform.position, saltoPos, tiempoTranscurrido / tiempoEnElAire);
            tiempoTranscurrido += Time.deltaTime;
            yield return null; // Espera un frame
        }
        float distT = Vector3.Distance(jugador.transform.position, transform.position);
        if (distT < distN)
        {
            Player Jscript = jugador.GetComponent<Player>();
            if (Jscript != null)
            {
                Jscript.RecibirDaño(damage);
            }
        }

        // Esperar en el suelo
        Debug.Log("Tiempo espera salto " + tiempoEsperaSalto);
        yield return new WaitForSeconds(tiempoEsperaSalto);
        yield return StartCoroutine(Saltar());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerVerdadero"))
        {
            Ataque(collision.gameObject);
        }
    }

    void Ataque(GameObject jugador)
    {
        Player Jscript = jugador.GetComponent<Player>();
        if (Jscript != null)
        {
            Jscript.RecibirDaño(damage);
        }
    }
}