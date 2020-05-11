using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSkillEFX : MonoBehaviour
{
    [Header("子弹的伤害")]
    public int damage = 10;
    [Header("暴击率")]
    [Range(0, 100)]
    public float CritPos = 0;
    [Header("暴击伤害百分比")]
    public int CritDmgMultiplier = 150;
    public int Camp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (Random.Range(0, 100) < CritPos)
            {
                collision.GetComponent<EnemyHp>().Damage(damage * CritDmgMultiplier / 100);
            }
            else
            {
                collision.GetComponent<EnemyHp>().Damage(damage);
            }
            GetComponent<CircleCollider2D>().enabled = false;
        }
        if (collision.tag == "Boss")
        {
            if (Random.Range(0, 100) < CritPos)
            {
                collision.GetComponent<BossHp>().Damage(damage * CritDmgMultiplier / 100);
            }
            else
            {
                collision.GetComponent<BossHp>().Damage(damage);
            }
            GetComponent<CircleCollider2D>().enabled = false;
        }
        if (collision.gameObject.layer == 12 && collision.GetComponentInChildren<Attack>().Camp != Camp)//Player
        {
            if (Random.Range(0, 100) < CritPos)
            {
                collision.GetComponent<HealthBar>().Damage(damage * CritDmgMultiplier / 100);
            }
            else
            {
                collision.GetComponent<HealthBar>().Damage(damage);
            }
            GetComponent<CircleCollider2D>().enabled = false;
        }
        if (collision.tag == "Flag" && collision.GetComponent<Flag>())
        {
            collision.GetComponent<Flag>().Damage(damage);
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }

}
