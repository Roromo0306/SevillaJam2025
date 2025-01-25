using UnityEngine;

public class MovHabitaciones : MonoBehaviour
{
    public Transform targetRoom; // La habitaci�n a la que lleva esta puerta
    public Transform player; // Referencia al jugador

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Si el jugador toca la puerta
        {
            // Mueve al jugador al centro de la nueva habitaci�n
            player.position = targetRoom.position;
        }
    }
}
