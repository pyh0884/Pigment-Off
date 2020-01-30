using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAi1 : MonoBehaviour
{
    public float AttackGap = 2;
    private float timer;
    public GameObject bullet;
    public Transform EmitPoint;
    public int BossNum = 0;
    void Update()
    {
        timer += Time.deltaTime;
        if (AttackGap <= timer)
        {
            var bullet1=Instantiate(bullet,EmitPoint.position,Quaternion.identity);
            //bullet1.GetComponent<BulletAI>().ColorType = BossNum;
            timer = 0;
        }
    }
}
