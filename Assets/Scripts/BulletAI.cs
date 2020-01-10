using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAI : MonoBehaviour
{
    public bool isEnemy;
    public bool fromBoss;
    [Header("射速")]
    public float ShootSpeed;
    [Header("射程")]
    public float Range=30;
    private Rigidbody2D rb;
    [Header("子弹的伤害")]
    public int damage = 10;
    [Header("暴击率")]
    [Range(0, 100)]
    public float CritPos = 0;
    [Header("暴击伤害百分比")]
    public int CritDmgMultiplier = 150;
    public GameObject ColorPool1;
    public GameObject ColorPool2;
    public GameObject ColorPool3;
    public int ColorType;
    public GameObject spr;
    public void SetInitial(Vector3 direction)
    {
        rb.velocity = new Vector2(direction.x, direction.y).normalized * ShootSpeed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,Range/ShootSpeed);
        if (isEnemy)  
        {
            FindEnemy();
            Vector3 dir = nearest2.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            rb.velocity = dir.normalized * ShootSpeed;
        }
    }
    Collider2D nearest;
    Collider2D nearest2;
    public LayerMask enemyLayer; //敌人AI使用
    void FindEnemy()
    {
        Collider2D[] list = Physics2D.OverlapCircleAll(transform.position, 150, enemyLayer);
            nearest = list[0];
            nearest2 = list[0];
            foreach (Collider2D col in list)
            {
                if (Vector2.Distance(new Vector2(col.transform.position.x, col.transform.position.y), new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)) <= Vector2.Distance(new Vector2(nearest.transform.position.x, nearest.transform.position.y), new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)))
                {
                    nearest2 = nearest;
                    nearest = col;
                }
            }
        if (nearest == nearest2) { nearest2 = list[1]; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Instantiate(spr, transform.position, Quaternion.identity);
            if (Random.Range(0, 100) < CritPos)
            {
                collision.GetComponent<EnemyHp>().Damage(damage * CritDmgMultiplier / 100);
            }
            else
            {
                collision.GetComponent<EnemyHp>().Damage(damage);
            }
            Destroy(gameObject);
        }
        if (collision.tag == "Boss"&& !fromBoss)
        {
            Instantiate(spr, transform.position, Quaternion.identity);
            if (Random.Range(0, 100) < CritPos)
            {
                collision.GetComponent<BossHp>().Damage(damage * CritDmgMultiplier / 100);
            }
            else
            {
                collision.GetComponent<BossHp>().Damage(damage);
            }
            collision.GetComponent<BossHp>().HitByPlayer = !isEnemy;
            Destroy(gameObject);
        }
        if (isEnemy && collision.gameObject.layer == 12)
        {
            Instantiate(spr, transform.position, Quaternion.identity);
            if (Random.Range(0, 100) < CritPos)
            {
                collision.GetComponent<HealthBar>().Damage(damage * CritDmgMultiplier / 100);
            }
            else
            {
                collision.GetComponent<HealthBar>().Damage(damage);
            }
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        switch (ColorType)
        {
            case 0:
                Instantiate(ColorPool1, gameObject.transform.position, Quaternion.identity);
                break;
            case 1:
                Instantiate(ColorPool2, gameObject.transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(ColorPool3, gameObject.transform.position, Quaternion.identity);
                break;
            default:
                Instantiate(ColorPool1, gameObject.transform.position, Quaternion.identity);
                break;
        }

    }
}
