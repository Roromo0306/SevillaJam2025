using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPausa : MonoBehaviour
{
    public GameObject botonPausa;
    public GameObject menuPausa;
    public void Pausa()
    {
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void VolverMenu(string nombre)
    {
        Time.timeScale = 1f; //Para que al volver al menu salga la transicion con la animacion
        SceneManager.LoadScene(nombre);
    }

    public void QuitarJuego()
    {
        Application.Quit();
        Debug.Log("Se ha cerrado");
    }
}
