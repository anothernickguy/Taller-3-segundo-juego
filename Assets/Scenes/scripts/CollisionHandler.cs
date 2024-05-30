using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject objectToDisable;
    public GameObject objectToEnable;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Portal"))
        {
            if (objectToDisable != null)
            {
                objectToDisable.SetActive(false);
            }

            if (objectToEnable != null)
            {
                objectToEnable.SetActive(true);
            }
        }
    }
}
