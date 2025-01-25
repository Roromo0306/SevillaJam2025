using UnityEngine;

public class CamaraSeguimiento : MonoBehaviour
{
    Transform player; // Referencia al jugador
    public float height = 5.55f; // Altura fija de la c�mara
    private float fixedX; // Guarda la posici�n X fija de la c�mara



    private void Start()
    {
        player = Player.Instance.transform;
        fixedX = player.position.x; 

    }

    private void LateUpdate()
    {
        transform.position = new Vector3(fixedX, height, player.position.z - 12f);
    }

    public void UpdateCameraPosition(Vector3 newRoomPosition)
    {
        fixedX = newRoomPosition.x; 
        transform.position = new Vector3(fixedX, height, newRoomPosition.z + player.position.z - 12f);
    }
}
