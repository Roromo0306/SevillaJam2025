using UnityEngine;

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
