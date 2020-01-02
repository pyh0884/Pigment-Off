using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public GameObject EmitPoint;
    Vector3 dir;
    private LineRenderer laser;
    private RaycastHit2D hit;
    void Start()
    {
        laser = GetComponent<LineRenderer>();
    }
    void Update()
    {
        dir = Input.mousePosition - Camera.main.WorldToScreenPoint(EmitPoint.transform.position);
        laser.SetPosition(0, EmitPoint.transform.position);
        hit = Physics2D.Raycast(EmitPoint.transform.position, new Vector2(dir.x, dir.y), Mathf.Infinity);
        //if (hit.collider!=null)
        //{
            laser.SetPosition(1, hit.point);
            //Debug.DrawLine(EmitPoint.transform.position,hit.point);
        //}
    }
}
