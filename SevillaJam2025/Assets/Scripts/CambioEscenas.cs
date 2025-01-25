using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscenas : MonoBehaviour
{
    public void CambiarEscena (string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void QuitarJuego()
    {
        Application.Quit();
        Debug.Log("Se ha cerrado");
    }
}
