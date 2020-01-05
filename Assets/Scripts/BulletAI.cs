using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAI : MonoBehaviour
{
    public bool isEnemy;
    public float ShootSpeed;
    public float LastTime;
    private Rigidbody2D rb;
    [Header("子弹的伤害")]
    public int damage = 1;
    public GameObject ColorPool1;
    public GameObject ColorPool2;
    public GameObject ColorPool3;
    private int ColorType;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,LastTime);
        if (!isEnemy)
        {
            Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            rb.velocity = new Vector2(dir.x, dir.y).normalized * ShootSpeed;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
        else
        {
            FindEnemy();
            Vector3 dir = nearest2.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            rb.velocity = dir.normalized * ShootSpeed;
        }
        ColorType = Mathf.FloorToInt(Random.Range(0, 3));
    }
    Collider2D nearest;
    Collider2D nearest2;
    public LayerMask enemyLayer;
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
            collision.GetComponent<BossHp>().Damage(damage);
            Destroy(gameObject);
        }
        if (collision.tag == "Boss")
        {
            collision.GetComponent<BossHp>().Damage(damage);
            collision.GetComponent<BossHp>().HitByPlayer = !isEnemy;
            Destroy(gameObject);
        }
        if (isEnemy && collision.tag == "Player")
        {
            collision.GetComponent<HealthBar>().Damage(damage);
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
