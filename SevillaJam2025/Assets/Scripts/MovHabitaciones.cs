using UnityEngine;

public class MovHabitaciones : MonoBehaviour
{
    public Transform targetRoom; // La habitaci�n a la que lleva esta puerta
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
    }
}
