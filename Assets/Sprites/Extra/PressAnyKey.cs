using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    public GameObject StartGame;

    void Update()
    {
        if (Input.anyKey)
        {
            Destroy(gameObject, 0.1f);
            StartGame.SetActive(true);
        }
    }
}
