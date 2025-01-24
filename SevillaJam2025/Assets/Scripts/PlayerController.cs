using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidadMovimiento = 15f;
    float CoordX, CoordY, CoordZ;

    public Rigidbody rb;
    Vector3 vector = new Vector3();

    public bool canDash = true;
    public bool isDashing = false; 
    float dashingSpeed = 2.2f;
    float dashingTime = 0.3f;
    float dashCooldown = 0.3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        
    }

    public IEnumerator Dash()
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
}
