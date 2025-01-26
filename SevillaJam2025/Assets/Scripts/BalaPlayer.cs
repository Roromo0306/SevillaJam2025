using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class BalaPlayer : MonoBehaviour
{

    public float velocidad = 8f;

    public float daño;

    public Player player;

    public float direccion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = Player.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(direccion * velocidad * Time.deltaTime, 0), Space.World);
       
    }

    public void mirarBala(float direccion)
    {
        this.direccion = direccion;
    }


    private void OnCollisionEnter(Collision collision)
    {
        VidaEnemigos vida = collision.collider.GetComponent<VidaEnemigos>();
        if (vida != null)
        {
            Debug.Log("Disparo recibido");
            vida.DamageDisparo(player.dañoDisparo);
        }
    }
    
}
