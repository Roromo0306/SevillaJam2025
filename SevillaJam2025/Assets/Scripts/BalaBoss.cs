using System.Collections;
using UnityEngine;

public class BalaBoss : MonoBehaviour
{
    private float damage = 1.5f;
    private GameObject jugador, bala;

    //Perseguir
    private float velocidad = 3f;
    private Rigidbody rb;
    private Vector3 direccion;

    private float tiempInicial = 0f;
    private float tiempFinal = 7000f;

    private BoxCollider Trig;
    private bool accionA = true;
    void Start()
    {
        bala = this.gameObject;
        jugador= GameObject.FindGameObjectWithTag("PlayerVerdadero");
        Trig = bala.GetComponent<BoxCollider>();
        StartCoroutine(Alternar());

        direccion = (jugador.transform.position - transform.position).normalized;
    }

    
    void Update()
    {
        transform.position += direccion * velocidad * Time.deltaTime;

        temporizador();
        //Debug.Log("El tiempo inicial es " + tiempInicial);
    }

    private void temporizador()
    {
        tiempInicial++;
        if (tiempInicial == tiempFinal)
        {
            Destroy(this.gameObject);
        }
    
        
    }

    IEnumerator Alternar()
    {
        while (true)
        {
            if (accionA)
            {
                Trig.isTrigger = true;
            }
            else
            {
                Trig.isTrigger = false;
            }
            accionA = !accionA;
            yield return new WaitForSeconds(4f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject jugadorC = collision.gameObject;
        if (jugador.tag == "PlayerVerdadero")
        {
            ataque(jugador);
        }
    }

    private void ataque(GameObject jugador)
    {
        Player Jscript = jugador.GetComponent<Player>();

        Jscript.vida = Jscript.vida - 1;
        Destroy(this.gameObject);
    }
}
