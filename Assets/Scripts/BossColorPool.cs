using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossColorPool : MonoBehaviour
{
    public bool Poison;
    private float PoisonTimer = 1;
    private float timer = 0;
    public bool Alcohol;
    public bool Icey;
    void Start()
    {
        Destroy(gameObject, 6);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            //技能1：毒液
            if (Poison&&timer >= PoisonTimer)
            {
                collision.GetComponentInChildren<HealthBar>().Damage(5);
                timer = 0;
            }
            //技能2：酒精
            if (Alcohol)
            {
                collision.GetComponentInChildren<PlayerMovement>().Slowed = true;
                collision.GetComponentInChildren<Attack>().MpSlow = true;
            }
            //技能3：冰面
            if (Icey)
            {
                collision.GetComponentInChildren<PlayerMovement>().Boost = true;
                collision.GetComponentInChildren<Attack>().CanAttack = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            collision.GetComponentInChildren<PlayerMovement>().Slowed = false;
            collision.GetComponentInChildren<Attack>().MpSlow = false;
            collision.GetComponentInChildren<Attack>().CanAttack = true;
            collision.GetComponentInChildren<PlayerMovement>().Boost = false;
        }

    }
    private void Update()
    {
        timer += Time.deltaTime;
    }
}
