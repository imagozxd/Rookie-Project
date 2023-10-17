using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject balaPrefab;

    void Update()
    {        
        if (Input.GetButtonDown("Fire1"))
        {
            Disparar();
        }
    }

    void Disparar()
    {        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        Vector2 direccion = (mousePosition - transform.position).normalized;
        
        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);
        
        BulletPlayer bulletScript = bala.GetComponent<BulletPlayer>();
        bulletScript.Inicializar(direccion);
    }
}


