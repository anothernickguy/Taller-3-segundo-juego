using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb2d;
    private bool isFalling = false;

    void Start()
    {
        // Obtener el componente Rigidbody2D del objeto
        rb2d = GetComponent<Rigidbody2D>();

        if (rb2d == null)
        {
            Debug.LogError("No se encontró un componente Rigidbody2D en el objeto.");
            return;
        }

        // Inicialmente, deshabilitamos la física del Rigidbody2D para que el objeto no caiga
        rb2d.isKinematic = true;
    }

    void Update()
    {
        // Si no hay Rigidbody2D, no hacer nada
        if (rb2d == null) return;

        // Movimiento del objeto con las flechas izquierda y derecha
        float move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        // Al presionar la barra espaciadora, se suelta el objeto
        if (Input.GetKeyDown(KeyCode.Space) && !isFalling)
        {
            rb2d.isKinematic = false;
            isFalling = true;
        }
    }
}

