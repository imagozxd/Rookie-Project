using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public int dañoPorImpacto = 1; 
    public float tiempoDestruccion = 3.0f; 
    private int impactos = 0; 
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Impacto en el jugador");
            collision.gameObject.GetComponent<PlayerHealth>().RecibirDaño(dañoPorImpacto);
        }       

        impactos++;

        if (impactos >= 4)
        {
            Debug.Log("Bala destruida después de 4 impactos");
            Destroy(gameObject);
        }
    }



}


