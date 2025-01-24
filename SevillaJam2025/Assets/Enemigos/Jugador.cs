using Unity.VisualScripting;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private float vel;
    private Rigidbody rb;
    private float cordX, cordY, cordZ, d;
    private Vector3 pos;

    //Daño y atacar
    private GameObject jugador, enemigoN;
    private float vida = 5f;
    private float daño = 2f;
    private float distM = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vel = 8.9f;
        rb = GetComponent<Rigidbody>();
        jugador = this.gameObject;
        enemigoN = GameObject.FindGameObjectWithTag("Enemigo_normal");
        
    }

    // Update is called once per frame
    void Update()
    {
        cordY = rb.linearVelocity.y;
        cordX = Input.GetAxis("Horizontal") * vel;
        cordZ = Input.GetAxis("Vertical") * vel;
        pos = new Vector3(cordX, cordY, cordZ);
        rb.linearVelocity = pos;
        Debug.Log("La vida del jugador es " + vida);

        float dist = Vector3.Distance(jugador.transform.position, enemigoN.transform.position);
        if (dist <= distM)
        {
            atacar(enemigoN);
        }
    }

    public void atacar(GameObject enemigo)
    {
        Enemigo escript = enemigo.GetComponent<Enemigo>();
        if (Input.GetKeyDown(KeyCode.E))
        {
            escript.vida = escript.vida - 1;
        }
    }

    public void RecibirDaño(float damage)
    {
        vida = vida - damage;

        if (vida <= 0)
        {
            Debug.Log("El jugador ha muerto");
            Destroy(jugador);

        }
    }
}
