using UnityEngine;
using UnityEngine.InputSystem;


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
        //Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));


        Vector2 direccion = ((Vector2)worldMousePosition - (Vector2)transform.position).normalized;


        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);
        
        BulletPlayer bulletScript = bala.GetComponent<BulletPlayer>();
        bulletScript.Inicializar(direccion);
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Disparar();
            Debug.Log("disparo");
            Debug.Log(context);
        }
    }
}


