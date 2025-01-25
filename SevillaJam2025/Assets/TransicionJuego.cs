using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TransicionJuego : MonoBehaviour
{
    //VARIABLES
    private Animator animator;

    [SerializeField] private AnimationClip animacionFinal;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Puesto con tecla para cambiarlo
        {
            StartCoroutine(CambiarEscena());
        }
    }

    IEnumerator CambiarEscena()
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);

        SceneManager.LoadScene("Juego");

    }
}
