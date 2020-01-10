using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    Collider2D nearest;
    Collider2D nearest2;
    public LayerMask enemyLayer;
    public float timer1=2;
    public float AttackTimer;
    public float moveTimer=2;
    public float HitBackForce = 5;
    public float HitBackTime = 0.1f;
    private float hitBackTime = 0;
    private Vector2 movement;
    public float moveSpeed = 10;
    public GameObject Bullet;
    public GameObject EmitPos;
    public GameObject GunSprite;
    int direction;
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

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        anim.SetBool("Walk", true); 
        hitBackTime = 0;
        FindEnemy();
    }

    void Update()
    {
        if (!nearest2) { FindEnemy(); }
        hitBackTime += Time.deltaTime;
        moveTimer += Time.deltaTime;
        if (moveTimer >= 1.5f)
        {
            if (Random.Range(0, 100) > 40)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }
            movement = new Vector2((nearest2.transform.position - transform.position).x, (nearest2.transform.position - transform.position).y).normalized * direction;
            moveTimer = 0;
        }
        if (hitBackTime > HitBackTime)
        {
            rb.velocity = Vector2.zero;
        }
        timer1 += Time.deltaTime; //切换目标
        AttackTimer += Time.deltaTime; //攻击间隔
        if (timer1 >= 5)
        {
            FindEnemy();
            timer1 = 0;
        }
        if (AttackTimer >= 1.5f)
        {
            AttackTimer = 0;
            Shoot();
        }
        if (nearest2.transform.position.x-transform.position.x<0)
        {
            rb.transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            rb.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        Vector3 dir = nearest2.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        GunSprite.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


    }
    public void Shoot()
    {
        hitBackTime = 0;
        Vector3 dir = nearest2.transform.position-transform.position;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * HitBackForce * -1;
        anim.SetTrigger("Attack");
        Instantiate(Bullet, EmitPos.transform.position, Quaternion.identity);
    }

    void FixedUpdate()
    {
        if (nearest2)
        {
            rb.position = (rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
