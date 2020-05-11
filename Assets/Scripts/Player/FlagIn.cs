using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagIn : MonoBehaviour
{
    public GameObject flagCover;
    [HideInInspector] public bool Unpaused;
    
    void Update()
    {
        if (Unpaused) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f);
        }
    }
    private void OnDestroy()
    {
        var flag = Instantiate(flagCover, transform.position, Quaternion.identity);
        flag.transform.parent = null;
    }
}
