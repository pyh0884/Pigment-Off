using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDes : MonoBehaviour
{
    public bool des;
    void Start()
    {if(des)
        Destroy(gameObject, 0.2f);
    }
    public void destroySelf() 
    {
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
}
