using UnityEngine;

public class MovHabitaciones : MonoBehaviour
{
    public Transform targetRoom; // La habitación a la que lleva esta puerta
    public Transform centroHabitacion;
    public GameObject mensajePuertaBloqueadaUI; // El UI de mensaje de puerta bloqueada
    private bool puertaDesbloqueada = false; // Variable que controlará si la puerta está desbloqueada o no
    Transform player;
    CamaraSeguimiento camara;
    public Collider puertaCollider;

    void Start()
    {
        player = Player.Instance.transform;
        camara = Camera.main.GetComponent<CamaraSeguimiento>();
        mensajePuertaBloqueadaUI.SetActive(false); // Asegurarse de que el mensaje esté desactivado al principio
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Si la puerta está bloqueada, mostramos el mensaje y desactivamos la colisión
            if (!puertaDesbloqueada)
            {
                mensajePuertaBloqueadaUI.SetActive(true); // Mostrar mensaje de puerta bloqueada
                puertaCollider.enabled = false; // Desactivar la colisión para que no pueda atravesar la puerta
            }
            else
            {
                // Si la puerta está desbloqueada, mover al jugador
                Vector3 entrada = targetRoom.position + (targetRoom.forward * 1.5f);
                player.position = entrada;

                // Ajusta la cámara a la posición de la nueva habitación
                camara.UpdateCameraPosition(centroHabitacion.position);

                // Activar la colisión de la puerta (por si estaba desactivada)
                puertaCollider.enabled = true;
            }
        }
    }

    // Este método se llamará para desbloquear la puerta (puede ser llamado cuando todos los enemigos sean derrotados)
    public void DesbloquearPuerta()
    {
        puertaDesbloqueada = true;
        mensajePuertaBloqueadaUI.SetActive(false); // Ocultar el mensaje
    }
}

/* public Transform targetRoom; // La habitación a la que lleva esta puerta
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
    }*/
