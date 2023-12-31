using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int vidaMaxima = 4; 
    public int vidaActual; 
    public event Action<int> EventoDaņo;


    void Start()
    {        
        vidaActual = vidaMaxima;
    }

    void Update()
    {
        vidaMaxima = vidaActual;        
    }
  
    public void RecibirDaņo(int cantidad)
    {
        
        vidaActual -= cantidad;
        
        vidaActual = Mathf.Max(vidaActual, 0);

        Debug.Log("Vida actual del jugador: " + vidaActual); 
        if (vidaActual <= 0)
        {
            
            Destroy(gameObject);
        }
        EventoDaņo?.Invoke(cantidad); 
    }
}







