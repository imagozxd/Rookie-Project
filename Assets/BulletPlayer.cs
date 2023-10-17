using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public float velocidad = 10f; 
    private Vector2 direccion; 
        
    public void Inicializar(Vector2 direccionInicial)
    {
        direccion = direccionInicial.normalized;
    }

    void Update()
    {        
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            Destroy(gameObject);
            Destroy(collision.gameObject); 
        }
    }

    void Start()
    {        
        Destroy(gameObject, 3.0f);
    }

}
