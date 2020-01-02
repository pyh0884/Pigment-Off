using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeShake : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
//        Debug.Log("Tree shake");
        GetComponentInChildren<Animator>().SetTrigger("Shake");
    }


}
