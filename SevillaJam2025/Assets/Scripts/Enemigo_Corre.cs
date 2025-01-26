using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemigo_Corre : MonoBehaviour
{
    
    private float damage = 4f;
    GameObject jugador, enemigo;
    public GameObject moneda;
    private Transform posicionMoneda;
  

    //Perseguir
    private float distM = 5f;
    private float velocidad = 4f;
    private Rigidbody rb;
    void Start()
    {
        enemigo = this.gameObject;
        jugador = GameObject.FindGameObjectWithTag("PlayerVerdadero");
        
   
    }

    
    void Update()
    {
        if (jugador == null)
        {
            return;
        }
        if (VidaEnemigos.Vida_Corre <= 0)
        {
            Destroy(enemigo);
        }

        float dist = Vector3.Distance(jugador.transform.position, enemigo.transform.position);
        if(dist < distM)
        {
            perseguir();
        }
    }

    private void perseguir()
    {
        //enemigo.transform.LookAt(jugador.transform.position);
        transform.position = Vector3.MoveTowards(enemigo.transform.position, jugador.transform.position, velocidad * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject jugadorC = collision.gameObject;
        if(jugadorC.tag == "PlayerVerdadero")
        {
            Player Jscript = jugador.GetComponent<Player>();
            Jscript.vida = Jscript.vida - 10;
            Destroy(enemigo);
            Instantiate(moneda, posicionMoneda.position, Quaternion.identity);
        }
    }
}
