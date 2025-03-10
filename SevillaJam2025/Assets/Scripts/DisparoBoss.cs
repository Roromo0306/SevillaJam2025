using UnityEngine;

public class DisparoBoss : MonoBehaviour
{
    public GameObject B;
    public float temEn = 3f;
    public Transform tirador;
    private float tiempRes;

    void Start()
    {
        tiempRes = temEn;
    }

    
    void Update()
    {
        tiempRes -= Time.deltaTime;
        if (tiempRes <= 0)
        {
            GenerarBalas();
            tiempRes = temEn;
        }
    }

    public void GenerarBalas()
    {
        Transform puntoDeSpawn = tirador.transform;

        Quaternion rotEjeX = Quaternion.Euler(0, 0, 0);

        GameObject bala1 = Instantiate(B, puntoDeSpawn.position, rotEjeX);
    }
}
