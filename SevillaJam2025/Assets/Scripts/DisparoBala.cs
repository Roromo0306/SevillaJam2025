using Unity.VisualScripting;
using UnityEngine;

public class DisparoBala : MonoBehaviour
{
    private float damage = 2f;
    private GameObject jugador, bala;
   

    //Perseguir
    private float velocidad = 3f;
    private Rigidbody rb;
    private Vector3 direccion;

    private float tiempInicial = 0f;
    private float tiempFinal = 200f;

  

    void Start()
    {
        bala = this.gameObject;
        jugador = GameObject.FindGameObjectWithTag("PlayerVerdadero");


        if (jugador == null)
        {
            return;
        }

        direccion = (jugador.transform.position - transform.position).normalized;
    }


    void Update()
    {
        transform.position += direccion * velocidad * Time.deltaTime;
        
        temporizador();
        Debug.Log("El tiempo inicial es " + tiempInicial);
    }

    private void temporizador()
    {
        tiempInicial++;
        if(tiempInicial == tiempFinal)
        {
            Destroy(this.gameObject);
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

    private void ataque (GameObject jugador)
    {
        Player Jscript = jugador.GetComponent<Player>();

        Jscript.vida = Jscript.vida - 1;
        Destroy(this.gameObject);
    }
}
