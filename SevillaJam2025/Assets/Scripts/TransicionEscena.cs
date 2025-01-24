using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscena : MonoBehaviour
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
        StartCoroutine(CambiarEscena());
    }

    IEnumerator CambiarEscena()
    {
        animator.SetTrigger("Iniciar");
        yield return new WaitForSeconds(animacionFinal.length);

        SceneManager.LoadScene("Prueba2Transicion");

    }













    /*public float tiempo = 5f; //Cambiar segun el tiempo que dure la animacion inicial
    public float contadorTransicion = 1.5f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        //Transicion de animacion a juego
        tiempo -= Time.deltaTime;
        if (tiempo <= 0)
        {
            animator.SetBool("Transicion", true);
            contadorTransicion -= Time.deltaTime;

            if (contadorTransicion <= 0)
                SceneManager.LoadScene("Prueba2Transicion");
        }
    }*/
}
