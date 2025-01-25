using UnityEngine;

public class CamaraSeguimiento : MonoBehaviour
{
    Transform player; // Referencia al jugador
    public float height = 5.55f; // Altura fija de la cámara
    private float fixedX; // Guarda la posición X fija de la cámara



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
