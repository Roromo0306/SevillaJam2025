using UnityEngine;

public class UI : MonoBehaviour
{
    public Player personaje;

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
        
    }

    public void masVelocidad()
    {     
        if(personaje.myCoins > 0)
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
                return;
            }
        }
        else if(personaje.myCoins == 0)
        {
            Debug.Log("No hay mas monedas ooo");
        }

            
    }

    
}

    



