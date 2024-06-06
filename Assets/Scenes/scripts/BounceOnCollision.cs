using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class BounceOnCollision : MonoBehaviour
{
    public float bounceForce = 10f;  // Fuerza de rebote
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar si el objeto colisionado tiene el tag "Player"
        if (collision.collider.CompareTag("Player"))
        {
            // Calcula la dirección de rebote
            Vector2 bounceDirection = collision.contacts[0].normal;

            // Aplica la fuerza de rebote
            rb.AddForce(-bounceDirection * bounceForce, ForceMode2D.Impulse);
        }
    }
}

