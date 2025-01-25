using UnityEngine;
using UnityEngine.UIElements;

public class BalaPlayer : MonoBehaviour
{

    public float velocidad = 8f;

    public float daño;

    public Player player;

    Vector2 direccion = new Vector2();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Player.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.CoordX < 0)
        {
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
        else if (player.CoordX > 0)
        {
            transform.Translate(direccion * velocidad * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        VidaEnemigos vida = other.GetComponent<VidaEnemigos>();
        if (vida != null)
        {
            Debug.Log("Disparo recibido");
            vida.DamageDisparo(player.dañoDisparo);
        }
    }
}
