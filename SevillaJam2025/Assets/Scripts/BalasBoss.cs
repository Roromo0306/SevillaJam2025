using UnityEngine;

public class BalasBoss : MonoBehaviour
{
    private float damage = 2f; // Da�o de la bala
    private GameObject jugador, bala;

    private float velocidad = 3f; // Velocidad de la bala
    private Rigidbody rb; // Referencia al Rigidbody de la bala
    private Vector3 direccion; // Direcci�n del movimiento de la bala

    private float tiempInicial = 0f;
    private float tiempFinal = 200f;
    private int ran; // Variable para determinar la direcci�n en el eje z

    void Start()
    {
        // Inicializaci�n
        bala = this.gameObject;
        jugador = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();

        // Genera un �ngulo aleatorio en el eje z
        ran = Random.Range(0, 360);

        // Calcula la direcci�n en funci�n del �ngulo aleatorio
        direccion = CalcularDireccion(ran);

        // Aplica fuerza para mover la bala
        rb.linearVelocity = direccion * velocidad;
    }

    void Update()
    {
        // Opcional: si deseas actualizar la direcci�n constantemente
        // ran = Random.Range(0, 360);
        // direccion = CalcularDireccion(ran);
        // rb.velocity = direccion * velocidad;
    }

    private Vector3 CalcularDireccion(int angulo)
    {
        // Convierte el �ngulo a radianes y calcula la direcci�n
        float radianes = angulo * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(radianes), 0, Mathf.Sin(radianes)); // X y Z cambian con el �ngulo
    }
}
