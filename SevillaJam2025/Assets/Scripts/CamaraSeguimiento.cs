using UnityEngine;

public class CamaraSeguimiento : MonoBehaviour
{
    Transform player; // Referencia al jugador
    public float height = 5.55f; // Altura fija de la cámara


    private void Start()
    {
        player = Player.Instance.transform;
    }

    private void LateUpdate()
    {
        // La cámara sigue al jugador, pero solo en X y Z, manteniendo la altura fija
        transform.position = new Vector3(player.position.x, height, player.position.z - 15.77f);
    }
}
