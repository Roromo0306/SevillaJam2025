using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float velocidadMovimiento = 6f;
    public float CoordX, CoordY, CoordZ;
    public float lastCoordX;

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
    public GameObject panelPregunta;

    public float vida = 6f;

    public float da�oAtaque = 10f;
    public float da�oDisparo = 4f;

    public GameObject AttackArea;
    public bool isAttacking = false;
    private float timeToAttack = 0.5f;
    private float timer = 0f;

    private GameObject jugador;

    public UI UI;

    public SpriteRenderer SpriteRenderer;
    public Animator animator;

    public ParticleSystem bubbles;
    public ParticleSystem bubblesAttack;

    public static Player Instance;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        panelTiendaPersonaje.SetActive(false);
        panelTiendaObjetos.SetActive(false);
        panelPregunta.SetActive(false);
        AttackArea.SetActive(false);
        jugador = this.gameObject;
        animator = GetComponent<Animator>();
       
        bubblesAttack.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (vida <= 0)
        {
            Debug.Log("El jugador ha muerto");
            Destroy(this.gameObject);
        } 
        if (isDashing)
        {
            return;
        }

        CoordX = Input.GetAxisRaw("Horizontal");
        if (CoordX != 0)
        {
            lastCoordX = CoordX;
        }

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
                animator.SetBool("isAttackingArea",true);
                bubblesAttack.Play();
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

        
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
                animator.SetBool("isMelee", true);
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
        

        Vector3 scale = transform.localScale;


        if (CoordX < 0)
        {
            scale.x = Mathf.Abs(scale.x); // Aseg�rate de que el objeto mire hacia la derecha
        }
        else if (CoordX > 0)
        {
            scale.x = -Mathf.Abs(scale.x); // Invierte el objeto para mirar hacia la izquierda
        }

        transform.localScale = scale;

        if(CoordZ != 0 || CoordX != 0)
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isAttackingArea", false);
            animator.SetBool("isMelee", false);
            bubblesAttack.Stop();
            bubbles.Play();
            
        }
        else
        {
            animator.SetBool("isRunning", false);
            bubbles.Stop();
            
        }

    }

    public float direccionSigno()
    {
        if(lastCoordX < 0)
        {
            return -1;
        }
        else if (lastCoordX > 0)
        {
            return 1;
        }

        return -1;
    }
    private void Awake()
    {
        
        
            Instance = this;
            DontDestroyOnLoad(transform.parent.gameObject);

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

        if (other.gameObject.CompareTag("Vater"))
        {
            panelPregunta.SetActive(true);
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
            panelTiendaObjetos.SetActive(false);
        }

        if (other.gameObject.CompareTag("Vater"))
        {
            panelPregunta.SetActive(false);
        }


    }

    private void Attack()
    {
        isAttacking = true;
        AttackArea.SetActive(isAttacking);
    }

    public void RecibirDa�o(float damage)
    {
        Debug.Log($"Recibido da�o: {damage}. Vida actual antes del da�o: {vida}");

        vida -= damage;

        Debug.Log($"Vida despu�s de recibir da�o: {vida}");

        if (vida <= 0)
        {
            Debug.Log("El jugador ha muerto");
            StartCoroutine(MuerteYCambioDeEscena("Ba�o"));
        }
    }

    private IEnumerator MuerteYCambioDeEscena(string nombreEscena)
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
        SceneManager.LoadScene("Ba�o");
    }

    public void OnCambioEscena(string sceneName)
    {

        if (sceneName == "Juego")
        {
            transform.position = new Vector3(80, 2.25f, 0);
        }
    }
}
