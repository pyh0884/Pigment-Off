using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlag : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<CircleCollider2D>().enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12) 
        {
            collision.GetComponentInChildren<Attack>().PickUp();
            Destroy(gameObject);
        }
    }
}
