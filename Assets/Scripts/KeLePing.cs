﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeLePing : MonoBehaviour
{
    public float LastTime = 8;
    void Start()
    {
        Destroy(gameObject, LastTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponentInChildren<Attack>().KeLe();
        }
        Destroy(gameObject);

    }

}