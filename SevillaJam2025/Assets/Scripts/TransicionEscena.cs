using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscena : MonoBehaviour
{
    //VARIABLES
    private Animator animator;

    [SerializeField] private AnimationClip animacionFinal;
    public float tiempo = 10f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space)) //Puesto con tecla para cambiarlo
        {
            StartCoroutine(CambiarEscena());
        }*/

        tiempo -= Time.deltaTime;

        if (tiempo <= 0)
        {
            StartCoroutine(CambiarEscena());
        }
    }

    IEnumerator CambiarEscena()
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);

        SceneManager.LoadScene("Ba�o");

    }













    /*public float tiempo = 5f; //Cambiar segun el tiempo que dure la animacion inicial
       
    void Update()
    {
        //Transicion de animacion a juego
        tiempo -= Time.deltaTime;

        if (tiempo <= 0)
        {
            StartCoroutine(CambiarEscena()); 
        }
    }*/
}
