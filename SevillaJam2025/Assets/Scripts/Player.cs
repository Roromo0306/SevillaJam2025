using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidadMovimiento = 6f;
    float CoordX, CoordY, CoordZ;

    public Rigidbody rb;
    Vector3 vector = new Vector3();

    public bool canDash = true;
    public bool isDashing = false; 
    float dashingSpeed = 2.2f;
    float dashingTime = 0.3f;
    float dashCooldown = 0.3f;

    public int myCoins = 0;

    public GameObject panelTiendaPersonaje;
    public GameObject panelTiendaObjetos;

    public int vida = 3;

    public float dañoAtaque = 10f;

    public GameObject AttackArea;
    public bool isAttacking = false;
    private float timeToAttack = 0.5f;
    private float timer = 0f;

    public UI UI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        panelTiendaPersonaje.SetActive(false);
        panelTiendaObjetos.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        CoordX = Input.GetAxisRaw("Horizontal");
        CoordZ = Input.GetAxisRaw("Vertical");

        vector = new Vector3(CoordX * velocidadMovimiento, 0, CoordZ* velocidadMovimiento);
        rb.linearVelocity = vector;

        if (Input.GetKeyDown(KeyCode.Space)&&canDash)
        {
            StartCoroutine(Dash());
        }

        if(UI.clicked == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Attack();
            }
            if (isAttacking)
            {
                timer += Time.deltaTime;
                if (timer >= timeToAttack)
                {
                    timer = 0f;
                    isAttacking = false;
                    AttackArea.SetActive(false);
                }
            }
        }
        
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        canDash = false;
        vector= new Vector3(CoordX * velocidadMovimiento * dashingSpeed, 0, CoordZ * velocidadMovimiento * dashingSpeed);
        rb.linearVelocity = vector;
        yield return new WaitForSeconds(dashingTime);
        isDashing =false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            myCoins++; ;
            
            Destroy(collision.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TiendaPersonaje"))
        {
            panelTiendaPersonaje.SetActive(true);
        }

        if (other.gameObject.CompareTag("TiendaObjetos"))
        {
            panelTiendaObjetos.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("TiendaPersonaje"))
        {
            panelTiendaPersonaje.SetActive(false);
        }

        if (other.gameObject.CompareTag("TiendaObjetos"))
        {
            panelTiendaObjetos.SetActive(false) ;
        }
    }

    private void Attack()
    {
        isAttacking = true;
        AttackArea.SetActive(isAttacking);
    }

}
