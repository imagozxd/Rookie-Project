using UnityEngine;

public class EnemyShootController : MonoBehaviour
{
    public GameObject balaPrefab; // Prefab de la bala
    public float frecuenciaDisparo = 1.0f; // Frecuencia de disparo en segundos
    private bool persecucionActiva = false; // Variable para verificar si la persecución está activada
    private float tiempoUltimoDisparo = 0f; // Tiempo del último disparo
    public Transform jugador;
    private EnemyMovement enemyMovement; // Referencia al script EnemyMovement

    void Start()
    {
        // Obtiene la referencia al script EnemyMovement
        enemyMovement = GetComponent<EnemyMovement>();
    }

    void Update()
    {
        // Actualiza la variable persecucionActiva según el valor de persiguiendo en EnemyMovement
        persecucionActiva = enemyMovement.persiguiendo;

        // Comprueba si la persecución está activada
        if (persecucionActiva)
        {
            // Comprueba si ha pasado el tiempo suficiente desde el último disparo
            if (Time.time - tiempoUltimoDisparo >= frecuenciaDisparo)
            {
                Disparar();
                tiempoUltimoDisparo = Time.time;
            }
        }
    }

    void Disparar()
    {       
            Vector2 direccion = (jugador.position - transform.position).normalized;
            GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);
            BulletEnemy bulletScript = bala.GetComponent<BulletEnemy>();
            bulletScript.Inicializar(direccion);
            Debug.Log("El enemigo dispara hacia el jugador");        
    }
}



