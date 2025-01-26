using UnityEngine;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    public Player personaje;

    float plusVelocidad = 1.2f;
    public int costeVelocidad = 1;
    int ContadorClicks = 0;
    int ContadorClicksDisparo = 0;
    int ContadorClicksmasAtaque = 0;
    int ContadorClicksmasVida = 0;
    int ContadorClicksmasVelocidad = 0;

    public int plusVida = 1;
    public int costeVida = 2;

    public float plusAtaque = 1.2f;
    public int costeAtaque = 2;

    public bool clicked = false;
    public int costeRafaga = 3;

    public int costeDisparo = 2;
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
            if (ContadorClicksmasVelocidad == 2)
            {
                Debug.Log("Lo siento, has llegado al maximo");
                return;
            }

            if (ContadorClicksmasVelocidad >= 0)
            {
                personaje.velocidadMovimiento *= plusVelocidad;
                Debug.Log("La velocidad ahora es " + personaje.velocidadMovimiento);
                personaje.myCoins -= costeVelocidad;
                Debug.Log("Me quedan " + personaje.myCoins);
                ContadorClicksmasVelocidad++;
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
            if (ContadorClicksmasVida == 2)
            {
                Debug.Log("Lo siento, has llegado al maximo");
                return;
            }

            if (ContadorClicksmasVida >= 0)
            {
                personaje.vida += plusVida;
                Debug.Log("La vida ahora es " + personaje.vida);
                personaje.myCoins -= costeVida;
                Debug.Log("Me quedan " + personaje.myCoins);
                ContadorClicksmasVida++;
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
            if (ContadorClicksmasAtaque == 2)
            {
                Debug.Log("Lo siento, has llegado al maximo");
                return;
            }

            if (ContadorClicksmasAtaque >= 0)
            {
                personaje.dañoAtaque *= plusAtaque;
                Debug.Log("El Ataque ahora es " + personaje.dañoAtaque);
                personaje.myCoins -= costeAtaque;
                Debug.Log("Me quedan " + personaje.myCoins);
                ContadorClicksmasAtaque++;
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
    public void UnlockDisparo()
    {
        if (personaje.myCoins > 0)
        {
            if (ContadorClicksDisparo == 1)
            {
                Debug.Log("Lo siento, has llegado al maximo");
                return;
            }

            if (ContadorClicksDisparo >= 0)
            {
                personaje.myCoins -= costeDisparo;
                Debug.Log("Has comprado el disparo de pompas");
                Debug.Log("Me quedan " + personaje.myCoins);
                ContadorClicksDisparo++;
                clicked = true;
            }

        }
        else if (personaje.myCoins == 0)
        {
            Debug.Log("No hay mas monedas ooo");
        }
    }
    public void volverBanio()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Baño");
    }
}

    



