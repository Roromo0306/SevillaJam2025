using System.Runtime.CompilerServices;
using UnityEngine;

public class DisparoPlayer : MonoBehaviour
{
    public Transform controladorBala;
    public GameObject bala;
    public Player player;

    public UI ui;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ui.clicked == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Disparar();
                player.animator.SetBool("isAttackingArea",true);
            }
        }
        
    }

    public void Disparar()
    {

        var balaInstance = Instantiate(bala, controladorBala.position, controladorBala.rotation);
        balaInstance.GetComponent<BalaPlayer>().mirarBala(player.direccionSigno());
    }


}
