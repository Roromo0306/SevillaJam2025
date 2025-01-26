using UnityEngine;

public class EnemigoDistancia : MonoBehaviour
{
    
    private GameObject jugador, enemigo;

    //Mirar
    private float distM = 4;
    private float velocidad = 3f;

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
        if (VidaEnemigos.Vida_Distancia <= 0)
        {
            Destroy(enemigo);
        }

        float dist = Vector3.Distance(jugador.transform.position, enemigo.transform.position);
        if (dist < distM)
        {
            //enemigo.transform.LookAt(jugador.transform.position);
        }
    }
}
