using UnityEngine;
using UnityEngine.SceneManagement;

public class TransicionEscena : MonoBehaviour
{
    //VARIABLES
    private Animator animator;
    public float tiempo = 5f; //Cambiar segun el tiempo que dure la animacion inicial
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        tiempo -= Time.deltaTime;
        if (tiempo <= 0)
        {
            SceneManager.LoadScene("Prueba2Transicion");
        }
    }
}
