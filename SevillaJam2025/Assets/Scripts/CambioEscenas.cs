using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenas : MonoBehaviour
{
    public GameObject panelPregunta;
    public void CambiarEscena (string nombre)
    {
        SceneManager.LoadScene(nombre);
        Player.Instance.OnCambioEscena(nombre);
    }

    public void CambiarCinematica(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void QuitarJuego()
    {
        Application.Quit();
        Debug.Log("Se ha cerrado");
    }

    public void QuitarPanel()
    {
        panelPregunta.SetActive(false);
    }
}
