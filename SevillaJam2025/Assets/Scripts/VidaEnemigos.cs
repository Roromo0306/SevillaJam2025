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

    public void Damage(float da�oAtaque)
    {
        Vida_Normal -= da�oAtaque;
        Vida_Tanque -= da�oAtaque;
        Vida_Corre -= da�oAtaque;
        Vida_Distancia -= da�oAtaque;
        VidaBoss -= da�oAtaque;

        Debug.Log($"{name} recibi� {da�oAtaque} de da�o. Vida restante: {Vida_Normal}");

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
            SceneManager.LoadScene("Ba�o");
        }
        
    }

    public void DamageDisparo(float da�oAtaque)
    {
        Vida_Normal -= da�oAtaque;
        Vida_Tanque -= da�oAtaque;
        Vida_Corre -= da�oAtaque;
        Vida_Distancia -= da�oAtaque;
        VidaBoss -= da�oAtaque;

        Debug.Log($"{name} recibi� {da�oAtaque} de da�o. Vida restante: {Vida_Normal}");

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

