using UnityEngine;

public class Balas : MonoBehaviour
{
    public GameObject B;
    public float tiemEn = 3f;
    public Transform tirador;
    private float tiempRes;

    void Start()
    {
        tiempRes = tiemEn;
        
    }

    
    void Update()
    {
        tiempRes -= Time.deltaTime;
        if(tiempRes <= 0)
        {
            GenerarBalas();
            tiempRes = tiemEn;
        }
    }

    public void GenerarBalas()
    {
        Transform puntoDeSpawn = tirador.transform;

        Quaternion rotEjeX = Quaternion.Euler(0, 0, 0);

        GameObject bala1 = Instantiate(B, puntoDeSpawn.position, rotEjeX);
    }
}
