using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int vidaMaxima = 4; 
    public int vidaActual; 
    public event Action<int> EventoDaño;


    void Start()
    {        
        vidaActual = vidaMaxima;
    }

    void Update()
    {
        vidaMaxima = vidaActual;        
    }
  
    public void RecibirDaño(int cantidad)
    {
        
        vidaActual -= cantidad;
        
        vidaActual = Mathf.Max(vidaActual, 0);

        Debug.Log("Vida actual del jugador: " + vidaActual); 
        if (vidaActual <= 0)
        {
            
            Destroy(gameObject);
        }
        EventoDaño?.Invoke(cantidad); 
    }
}







