using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAi1 : MonoBehaviour
{
    public float AttackGap = 2;
    private float timer;
    public GameObject bullet;
    public Transform EmitPoint;
    void Update()
    {
        timer += Time.deltaTime;
        if (AttackGap <= timer)
        {
            Instantiate(bullet,EmitPoint.position,Quaternion.identity);
            timer = 0;
        }
    }
}
