using UnityEngine;

public class AreaAttack : MonoBehaviour
{
    private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        VidaEnemigos vida = other.GetComponent<VidaEnemigos>();
        if (vida != null)
        {
            Debug.Log("Le estoy pegando");
            vida.Damage(player.dañoAtaque);
        }
        
    }
}
