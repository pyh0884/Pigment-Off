using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagIndicator : MonoBehaviour
{
    public Transform flag;
    public GameObject indicator;
    public float distance = 12;
    public float dis;
    void Update()
    {
        flag = GameObject.FindGameObjectWithTag("Flag").transform;
        var direction = flag.position - transform.position;
        dis = Vector2.Distance(flag.position,transform.position);
        if (dis > distance)
        {
            indicator.SetActive(true);
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            indicator.SetActive(false);
        }
    }
}
