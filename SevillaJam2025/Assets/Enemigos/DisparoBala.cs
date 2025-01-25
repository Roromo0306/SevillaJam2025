using Unity.VisualScripting;
using UnityEngine;

public class DisparoBala : MonoBehaviour
{
    private float damage = 2f;
    private GameObject jugador, bala;

    //Perseguir
    private float velocidad = 3f;
    private Rigidbody rb;
    void Start()
    {
        bala = this.gameObject;
        jugador = GameObject.Find("Player");
    }


    void Update()
    {
        perseguir();
    }

    private void perseguir()
    {
        bala.transform.position = Vector3.MoveTowards(bala.transform.position, jugador.transform.position, velocidad * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject jugadorC = collision.gameObject;
        if (jugador.tag == "Player")
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
