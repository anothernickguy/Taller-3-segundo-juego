using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float slowDownSpeed = 2f; // Velocidad reducida cuando se presiona espacio
    private Rigidbody2D rb2d;
    private Collider2D collider2d;
    private bool isFalling = false;
    public GameObject objetoAActivar; // Objeto que se activará

    void Start()
    {
        // Obtener el componente Rigidbody2D del objeto
        rb2d = GetComponent<Rigidbody2D>();

        // Obtener el componente Collider2D del objeto
        collider2d = GetComponent<Collider2D>();

        if (rb2d == null)
        {
            Debug.LogError("No se encontró un componente Rigidbody2D en el objeto.");
            return;
        }

        if (collider2d == null)
        {
            Debug.LogError("No se encontró un componente Collider2D en el objeto.");
            return;
        }

        // Inicialmente, deshabilitamos la física del Rigidbody2D para que el objeto no caiga
        rb2d.isKinematic = true;

        // Desactivar el objeto que se activará
        if (objetoAActivar != null)
        {
            objetoAActivar.SetActive(false);
        }
    }

    void Update()
    {
        // Si no hay Rigidbody2D, no hacer nada
        if (rb2d == null) return;

        // Comprobar si la tecla de espacio está presionada
        bool isSpacePressed = Input.GetKey(KeyCode.Space);

        // Movimiento del objeto con las flechas izquierda y derecha
        float move = Input.GetAxis("Horizontal") * (isSpacePressed ? slowDownSpeed : moveSpeed) * Time.deltaTime;
        transform.Translate(move, 0, 0);

        // Al presionar la barra espaciadora y soltar el objeto
        if (Input.GetKeyDown(KeyCode.Space) && !isFalling)
        {
            rb2d.isKinematic = false;
            isFalling = true;
        }

        // Al presionar la tecla "X" cambiar la gravedad del objeto, desactivar el collider y activar otro objeto
        if (Input.GetKeyDown(KeyCode.X))
        {
            rb2d.gravityScale = 0.5f;
            if (collider2d != null)
            {
                collider2d.enabled = false;
            }
            if (objetoAActivar != null)
            {
                StartCoroutine(ActivateObjectForSeconds(0.5f));
            }
        }
    }

    private IEnumerator ActivateObjectForSeconds(float seconds)
    {
        objetoAActivar.SetActive(true);
        yield return new WaitForSeconds(seconds);
        objetoAActivar.SetActive(false);
        if (collider2d != null)
        {
            collider2d.enabled = true;
        }
    }
}
