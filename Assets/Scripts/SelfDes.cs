using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDes : MonoBehaviour
{
    public bool des;
    public float time;
    void Start()
    {
        if (des && time == 0)
            Destroy(gameObject, 0.2f);
        if (time != 0)
        {
            Destroy(gameObject, time);
        }
    }
    public void destroySelf() 
    {
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
}
