using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassShake : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInChildren<Animator>().SetTrigger("Shake");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
     //  GetComponentInChildren<Animator>().SetTrigger("Shake");
    }
}
