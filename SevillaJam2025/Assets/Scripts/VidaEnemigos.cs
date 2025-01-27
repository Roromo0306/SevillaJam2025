using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaEnemigos : MonoBehaviour
{

    public float Vida_Normal = 5f, Vida_Tanque = 10f, Vida_Corre = 1f, Vida_Distancia = 3f, VidaBoss =20f;

    //public Player player;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("PlayerVerdadero").transform.GetChild(0).GetComponent<Player>();
        player = GameObject.FindGameObjectWithTag("PlayerVerdadero");
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float dañoAtaque)
    {
        Vida_Normal -= dañoAtaque;
        Vida_Tanque -= dañoAtaque;
        Vida_Corre -= dañoAtaque;
        Vida_Distancia -= dañoAtaque;
        VidaBoss -= dañoAtaque;

        Debug.Log($"{name} recibió {dañoAtaque} de daño. Vida restante: {Vida_Normal}");

        if(Vida_Normal <= 0)
        {
            Matar();
        }
        if (Vida_Tanque <= 0)
        {
            Matar();

        }
        if (Vida_Corre <= 0)
        {
            Matar();
        }
        if (Vida_Distancia <= 0)
        {
            Matar();
        }
        if(VidaBoss <= 0)
        {
            Matar();
        }
    }

    private void Matar()
    {
        
        Destroy(gameObject);
        if(player == null)
        {
            SceneManager.LoadScene("Baño");
        }
        
    }

    public void DamageDisparo(float dañoAtaque)
    {
        Vida_Normal -= dañoAtaque;
        Vida_Tanque -= dañoAtaque;
        Vida_Corre -= dañoAtaque;
        Vida_Distancia -= dañoAtaque;
        VidaBoss -= dañoAtaque;

        Debug.Log($"{name} recibió {dañoAtaque} de daño. Vida restante: {Vida_Normal}");

        if (Vida_Normal <= 0)
        {
            Matar();
        }
        if (Vida_Tanque <= 0)
        {
            Matar();

        }
        if (Vida_Corre <= 0)
        {
            Matar();
        }
        if (Vida_Distancia <= 0)
        {
            Matar();
        }
        if (VidaBoss <= 0)
        {
            Matar();
        }
    }

   
}

