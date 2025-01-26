using UnityEngine;
using UnityEngine.UI;

public class MovHabitaciones : MonoBehaviour
{
    public Transform targetRoom; // La habitación a la que lleva esta puerta
    public Transform centroHabitacion;
    Transform player;
    CamaraSeguimiento camara;

    void Start()
    {
        player = Player.Instance.transform;
        camara = Camera.main.GetComponent<CamaraSeguimiento>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 entrada = targetRoom.position + (targetRoom.forward * 1.5f);
            player.position = entrada;

            // Ajusta la cámara a la posición de la nueva habitación
            camara.UpdateCameraPosition(centroHabitacion.position);

        }
    }
}
    /*
    //public Transform targetRoom;  // La habitación a la que lleva esta puerta
    //public Transform centroHabitacion;  // El centro de la habitación

    Transform player;
    CamaraSeguimiento camara;

   // public GameObject muro;
   // public GameObject pasarSala;
    public GameObject panelPregunta;

    //private int enemigosRestantes;  // Número de enemigos restantes en la sala

    void Start()
    {
        // Inicializamos el número de enemigos en la sala
        //enemigosRestantes = GameObject.FindGameObjectsWithTag("Enemigo_normal").Length;

        player = Player.Instance.transform;
        camara = Camera.main.GetComponent<CamaraSeguimiento>();



    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.K))
        {
            //Destroy(muro.gameObject);
            Destroy(panelPregunta.gameObject);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("pregunta"))
        {
            panelPregunta.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("pregunta"))
        {
            panelPregunta.SetActive(true);
        }
    }




}
   /* public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "muro")
        {
            texto.text = "Hola";
            Debug.Log("funciona");
            contactoMuro = true;
        }
    }

    public void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "muro")
        {
            texto.text = "";
            contactoMuro = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (pasarSala.CompareTag("Player"))
        {
            Vector3 entrada = targetRoom.position + (targetRoom.forward * 1.5f);
            player.position = entrada;

            // Ajusta la cámara a la posición de la nueva habitación
            camara.UpdateCameraPosition(centroHabitacion.position);

        }
    }*/

// Esta función debe ser llamada cada vez que un enemigo muere
/*public void EnemigoMuerto()
{
    enemigosRestantes--;

    if (enemigosRestantes <= 0)
    {
        Destroy(muro.gameObject);
    }
}*/



