using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    public float rangoDeteccion = 6f; 
    public float velocidadPersecucion = 5f;

    public LayerMask capaJugador; 
    public bool persiguiendo = false;
    public Transform jugador; 
    private Vector3 posicionInicial;

    public event Action<bool> PersecucionChanged; 
    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        
        Vector2 direccion = jugador.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direccion, rangoDeteccion, capaJugador);

        
        Debug.DrawRay(transform.position, direccion.normalized * rangoDeteccion, Color.red);

        
        if (hit.collider == null)
        {
            persiguiendo = false;
            Debug.Log("Debería perseguir al jugador.");

        }
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            persiguiendo = true;
            Debug.Log("Debería perseguir al jugador."); 
        }
        else
        {
            persiguiendo = false;
            Debug.Log("Dejo de perseguir al jugador.");
        }

        
        if (persiguiendo)
        {            
            transform.position = Vector3.MoveTowards(transform.position, jugador.position, velocidadPersecucion * Time.deltaTime);
            PersecucionChanged?.Invoke(persiguiendo);
        }
        else
        {
           
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidadPersecucion * Time.deltaTime);
        }
    }
}




