using UnityEngine;

public class MovHabitaciones : MonoBehaviour
{
    public Transform targetRoom; // La habitaci�n a la que lleva esta puerta
    public Transform centroHabitacion;
    public GameObject mensajePuertaBloqueadaUI; // El UI de mensaje de puerta bloqueada
    private bool puertaDesbloqueada = false; // Variable que controlar� si la puerta est� desbloqueada o no
    Transform player;
    CamaraSeguimiento camara;
    public Collider puertaCollider;

    void Start()
    {
        player = Player.Instance.transform;
        camara = Camera.main.GetComponent<CamaraSeguimiento>();
        mensajePuertaBloqueadaUI.SetActive(false); // Asegurarse de que el mensaje est� desactivado al principio
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Si la puerta est� bloqueada, mostramos el mensaje y desactivamos la colisi�n
            if (!puertaDesbloqueada)
            {
                mensajePuertaBloqueadaUI.SetActive(true); // Mostrar mensaje de puerta bloqueada
                puertaCollider.enabled = false; // Desactivar la colisi�n para que no pueda atravesar la puerta
            }
            else
            {
                // Si la puerta est� desbloqueada, mover al jugador
                Vector3 entrada = targetRoom.position + (targetRoom.forward * 1.5f);
                player.position = entrada;

                // Ajusta la c�mara a la posici�n de la nueva habitaci�n
                camara.UpdateCameraPosition(centroHabitacion.position);

                // Activar la colisi�n de la puerta (por si estaba desactivada)
                puertaCollider.enabled = true;
            }
        }
    }

    // Este m�todo se llamar� para desbloquear la puerta (puede ser llamado cuando todos los enemigos sean derrotados)
    public void DesbloquearPuerta()
    {
        puertaDesbloqueada = true;
        mensajePuertaBloqueadaUI.SetActive(false); // Ocultar el mensaje
    }
}

/* public Transform targetRoom; // La habitaci�n a la que lleva esta puerta
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

            // Ajusta la c�mara a la posici�n de la nueva habitaci�n
            camara.UpdateCameraPosition(centroHabitacion.position);

        }
    }*/
