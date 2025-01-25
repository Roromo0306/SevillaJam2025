using UnityEngine;

public class BalaPlayer : MonoBehaviour
{

    public float velocidad;

    public float daño;

    public Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right* velocidad * Time.deltaTime);
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
