using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeLePing : MonoBehaviour
{
    public float LastTime = 8;
    void Start()
    {
        Debug.Log(LastTime);
        Destroy(gameObject, LastTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            //collision.gameObject.GetComponentInChildren<Attack>().KeLe();
            collision.gameObject.GetComponent<PlayerMovement>().PickUpItem(1);
        }
        Destroy(gameObject);

    }

}
