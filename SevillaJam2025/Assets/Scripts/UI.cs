using UnityEngine;

public class UI : MonoBehaviour
{
    public Player personaje;

    float plusVelocidad = 1.2f;
    public int costeVelocidad = 1;
    int ContadorClicks = 0;

    public int plusVida = 1;
    public int costeVida = 2;

    public float plusAtaque = 1.2f;
    public int costeAtaque = 2;

    public bool clicked = false;
    public int costeRafaga = 3;
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
            if (ContadorClicks == 2)
            {
                Debug.Log("Lo siento, has llegado al maximo");
                return;
            }

            if (ContadorClicks >= 0)
            {
                personaje.velocidadMovimiento *= plusVelocidad;
                Debug.Log("La velocidad ahora es " + personaje.velocidadMovimiento);
                personaje.myCoins -= costeVelocidad;
                Debug.Log("Me quedan " + personaje.myCoins);
                ContadorClicks++;
            }
            
        }
        else if(personaje.myCoins == 0)
        {
            Debug.Log("No hay mas monedas ooo");
        }            
    }

    public void masVida()
    {
        if (personaje.myCoins > 1)
        {
            if (ContadorClicks == 2)
            {
                Debug.Log("Lo siento, has llegado al maximo");
                return;
            }

            if (ContadorClicks >= 0)
            {
                personaje.vida += plusVida;
                Debug.Log("La vida ahora es " + personaje.vida);
                personaje.myCoins -= costeVida;
                Debug.Log("Me quedan " + personaje.myCoins);
                ContadorClicks++;
            }

        }
        else if (personaje.myCoins <=1)
        {
            Debug.Log("No hay mas monedas ooo");
        }
    }

    public void masAtaque()
    {
        if (personaje.myCoins > 1)
        {
            if (ContadorClicks == 2)
            {
                Debug.Log("Lo siento, has llegado al maximo");
                return;
            }

            if (ContadorClicks >= 0)
            {
                personaje.dañoAtaque *= plusAtaque;
                Debug.Log("El Ataque ahora es " + personaje.dañoAtaque);
                personaje.myCoins -= costeAtaque;
                Debug.Log("Me quedan " + personaje.myCoins);
                ContadorClicks++;
            }

        }
        else if (personaje.myCoins <= 1)
        {
            Debug.Log("No hay mas monedas ooo");
        }
    }

    public void UnlockRafagaPompas()
    {
        if (personaje.myCoins > 0)
        {
            if (ContadorClicks == 1)
            {
                Debug.Log("Lo siento, has llegado al maximo");
                return;
            }

            if (ContadorClicks >= 0)
            {
                personaje.myCoins -= costeRafaga;
                Debug.Log("Has comprado la rafaga de pompas");
                Debug.Log("Me quedan " + personaje.myCoins);
                ContadorClicks++;
                clicked = true;
            }

        }
        else if (personaje.myCoins == 0)
        {
            Debug.Log("No hay mas monedas ooo");
        }
    }
}

    



