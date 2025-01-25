using System.Runtime.CompilerServices;
using UnityEngine;

public class DisparoPlayer : MonoBehaviour
{
    public Transform controladorBala;
    public GameObject bala;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    public void Disparar()
    {

        var balaInstance = Instantiate(bala, controladorBala.position, controladorBala.rotation);
       // balaInstance.direccion = 
    }


}
