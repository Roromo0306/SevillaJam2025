using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemigo_Normal : MonoBehaviour
{
    
    private float damage = 2f;
    public GameObject jugador, enemigo;
    Transform player;

    //Perseguir
    private float distM = 4;
    private float velocidad = 3f;
    private Rigidbody rb;
    public GameObject moneda;
    private Transform posicionMoneda;
    void Start()
    {
        enemigo = this.gameObject;
        
        jugador = GameObject.FindGameObjectWithTag("PlayerVerdadero");
        player = Player.Instance.transform;

    }

    
    void Update()
    {
        if (jugador == null) {
            return;
        }
      
        if (VidaEnemigos.Vida_Normal <= 0)
        {
            Destroy(enemigo);
            Instantiate(moneda, posicionMoneda.position, Quaternion.identity);
        }

        float dist = Vector3.Distance(jugador.transform.position, enemigo.transform.position);
        
        if (dist < distM)
        {
           
            perseguir();
        }
       Debug.Log("La vida del enemigo es " + VidaEnemigos.Vida_Normal);
       //Debug.Log("La distancia es " + dist);

    }

    private void perseguir()
    {
        //enemigo.transform.LookAt(jugador.transform.position);
        transform.position = Vector3.MoveTowards(enemigo.transform.position, jugador.transform.position, velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject jugadorC = collision.gameObject;

        if (jugadorC.tag == "PlayerVerdadero")
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
