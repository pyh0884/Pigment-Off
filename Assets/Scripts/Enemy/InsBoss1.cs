using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsBoss1 : MonoBehaviour
{
    public GameObject boss1;
    public void ins() 
    {
        Instantiate(boss1, transform.position,Quaternion.identity);
    }
    public void des() 
    {
        Destroy(gameObject);
    }
}
