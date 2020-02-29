using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialGM : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<GameManager>().Initial();
    }

}
