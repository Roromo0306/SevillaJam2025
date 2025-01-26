using UnityEngine;
using UnityEngine.UI;

public class BloqPuertas : MonoBehaviour
{
    public GameObject bloq;
    public Text mensajeBloq;
    void Start()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerVerdadero"))
        {
            mensajeBloq.text = "LAS PUERTAS \r\nESTAN BLOQUEADAS.\r\n¡MATALOS!";
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerVerdadero"))
        {
            mensajeBloq.text = "";
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Destroy(this.gameObject);
            Destroy(mensajeBloq.gameObject);
        }
    }


}
