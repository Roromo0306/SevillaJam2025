using UnityEngine;

public class UI : MonoBehaviour
{
    PlayerController personaje = new PlayerController();

    float plusVelocidad = 1.2f;
    public int costeVelocidad = 1;
    int ContadorClicks = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(personaje.myCoins);
    }

    public void masVelocidad()
    {     
            if (ContadorClicks >= 0)
            {
                personaje.velocidadMovimiento *= plusVelocidad;
                Debug.Log("La velocidad ahora es " + personaje.velocidadMovimiento);
                personaje.myCoins -= costeVelocidad;
                Debug.Log("Me quedan " + personaje.myCoins);
                ContadorClicks++;
            }
            if (ContadorClicks == 2)
            {
                Debug.Log("Lo siento, has llegado al maximo");
            }
    }

    
}

    



