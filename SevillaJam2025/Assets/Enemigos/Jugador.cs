using Unity.VisualScripting;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    private float vel;
    private Rigidbody rb;
    private float cordX, cordY, cordZ, d;
    private Vector3 pos;


    //Daño y atacar
    private GameObject jugador, enemigoN, enemigoT, enemigoC;
    private float vida = 5f;
    private float daño = 2f;
    private float distM = 2f;
    //Retroceso
    private float distRetro = 1f;
    private float velocRetro = 2f;
    private Vector3 posObje;
    private bool enRetroceso = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vel = 8.9f;
        rb = GetComponent<Rigidbody>();
        jugador = this.gameObject;
        enemigoN = GameObject.FindGameObjectWithTag("Enemigo_normal");
        enemigoT = GameObject.FindGameObjectWithTag("Enemigo_Tanque");
        enemigoC = GameObject.FindGameObjectWithTag("Enemigo_Corre");
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

        float distT = Vector3.Distance(jugador.transform.position, enemigoT.transform.position);
        if(distT <= distM) 
        {
            atacarT(enemigoT);
        }

        float distC = Vector3.Distance(jugador.transform.position, enemigoC.transform.position);
        if (distC <= distM)
        {
            atacarC(enemigoC);
        }
    }

 

    public void atacar(GameObject enemigo)
    {
       
        if (Input.GetKeyDown(KeyCode.E))
        {
            VidaEnemigos.Vida_Normal = VidaEnemigos.Vida_Normal - 1;
           

        }
    }

    public void atacarT(GameObject enemigo)
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            VidaEnemigos.Vida_Tanque = VidaEnemigos.Vida_Tanque - 1;
        }
    }

    public void atacarC(GameObject enemigo)
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            VidaEnemigos.Vida_Corre = VidaEnemigos.Vida_Corre - 1;
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
