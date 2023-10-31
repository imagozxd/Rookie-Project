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

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {            
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Debug.Log("impacto3d");
        }
    }

    void Start()
    {
        
        Destroy(gameObject, 3.0f);
    }

}
