using UnityEngine;

public class DisparoBalasBoss : MonoBehaviour
{
    public GameObject B, B1, B2, B3, B4;
    public float tiemEn = 3f;
    public Transform tirador;
    private float tiemRes;
    private int r, r1, r2,r3,r4;
    void Start()
    {
        tiemRes = tiemEn;
        
    }


    void Update()
    {
        tiemRes -= Time.deltaTime;
        if(tiemRes <= 0)
        {
            GenerarBalas();
            tiemRes = tiemEn;
        }
    }

    private void GenerarBalas()
    {
        Transform puntoDeSpawn = tirador.transform;
        Quaternion rotEjex = Quaternion.Euler(0, 0, 0);
        GameObject bala = Instantiate(B, puntoDeSpawn.position, rotEjex);
        GameObject bala1 = Instantiate(B1, puntoDeSpawn.position, rotEjex);
        GameObject bala2 = Instantiate(B2, puntoDeSpawn.position, rotEjex);
        GameObject bala3 = Instantiate(B3, puntoDeSpawn.position, rotEjex);
        GameObject bala4 = Instantiate(B4, puntoDeSpawn.position, rotEjex);




    }
}
