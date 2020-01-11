using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPool : MonoBehaviour
{
    public float IncreaseShootingSpd = 1.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12 && (collision.tag == "Normal1" || collision.tag == "Normal2")) 
        {
            collision.GetComponentInChildren<Attack>().MpBoost = true;
            collision.GetComponentInChildren<Attack>().CdTime /= IncreaseShootingSpd;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12 && (collision.tag == "Normal1" || collision.tag == "Normal2"))
        {
            collision.GetComponentInChildren<Attack>().MpBoost = false;
            collision.GetComponentInChildren<Attack>().CdTime *= IncreaseShootingSpd;
        }

    }
    void Start()
    {
        Destroy(gameObject, 6);
    }

}
