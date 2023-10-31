using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7.5f;

    private Rigidbody2D rb;
    private EnemyMovement enemyMovement;

    public AudioSource playerAudioSource;
    public AudioClip bulletSound;
    public AudioClip PlayerHurtSound;
    public AudioClip correteo;
    //public event Action<int> EventoDaño;
    public event Action<bool> PersecucionChanged;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyMovement = GetComponent<EnemyMovement>();
        //int cantidad = 4;
        GetComponent<PlayerHealth>().EventoDaño += OnHurtPlayer;

        
        enemyMovement.PersecucionChanged += HandlePersecucionChanged;


    }
    private void Update()
    {
        //playerAudioSource.PlayOneShot(bulletSound);


    }
    
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        MovePlayer(movement);
    }

    void MovePlayer(Vector2 direction)
    {
        rb.velocity = direction * moveSpeed;
    }
    private void OnHurtPlayer(int cantidad)
    {
        playerAudioSource.PlayOneShot(PlayerHurtSound);
    }
    /*private void HandlePersecucionChanged(bool persiguiendo)
    {
        PersecucionChanged?.Invoke(persiguiendo);
    }*/
    private void HandlePersecucionChanged(bool persiguiendo)
    {
        if (persiguiendo)
        {
            playerAudioSource.clip = correteo;
            playerAudioSource.Play();
        }
        else
        {           
            playerAudioSource.Stop();
        }
    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
        Vector2 direction = context.ReadValue<Vector2>();
        rb.velocity = direction*moveSpeed;
    }
}
