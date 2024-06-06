using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InstaKill : MonoBehaviour
{
    public GameObject sangre;
    public UnityEvent onContact;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            onContact.Invoke();
            collision.gameObject.SetActive(false);
            Instantiate(sangre, collision.transform.position, Quaternion.identity);
        }
    }
}
