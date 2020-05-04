using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float LastTime = 8;
    void Start()
    {
        Destroy(gameObject, LastTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            collision.gameObject.GetComponent<HealthBar>().ShieldUp();
        }
        Destroy(gameObject);
    }
}
