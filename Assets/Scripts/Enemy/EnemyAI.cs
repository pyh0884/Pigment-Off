using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    //Collider2D nearest;
    //Collider2D nearest2;
    public Collider2D notMove;
    public LayerMask enemyLayer;
    public float timer1=2;
    public float AttackTimer;
    private Vector2 movement;
    public float moveSpeed = 10;
    public GameObject Bullet;
    public GameObject EmitPos;
    public float ShootSpeed;
    //public GameObject GunSprite;
    //void FindEnemy()
    //{
    //    Collider2D[] list = Physics2D.OverlapCircleAll(transform.position, 150, enemyLayer);
    //    nearest = list[0];
    //    nearest2 = list[0];
    //    foreach (Collider2D col in list)
    //    {
    //        if (Vector2.Distance(new Vector2(col.transform.position.x, col.transform.position.y), new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)) <= Vector2.Distance(new Vector2(nearest.transform.position.x, nearest.transform.position.y), new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)))
    //        {
    //            nearest2 = nearest;
    //            nearest = col;
    //        }
    //    }
    //    if (nearest == nearest2) { nearest2 = list[1]; }
    //}
    void FindNonMove()
    {
        Collider2D[] list = Physics2D.OverlapCircleAll(transform.position, 100, enemyLayer);
        notMove = list[0];
        foreach (Collider2D col in list)
        {
            if (col.gameObject.GetComponent<PlayerMovement>().MoveTimer + col.gameObject.GetComponentInChildren<Attack>().moveNum >= notMove.gameObject.GetComponent<PlayerMovement>().MoveTimer + notMove.gameObject.GetComponentInChildren<Attack>().moveNum) 
            {
                notMove = col;
            }
        }
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();        
        FindNonMove();
    }
    void Update() 
    { 
        if (!notMove) 
        {
            FindNonMove();
        }
        movement = new Vector2((notMove.transform.position - transform.position).x, (notMove.transform.position - transform.position).y).normalized;
        //切换目标
        timer1 += Time.deltaTime; 
        if (timer1 >= 7)
        {
            FindNonMove();
            timer1 = 0;
        } 
        //攻击间隔
        AttackTimer += Time.deltaTime;
        if (AttackTimer >= 2.5f && Vector2.Distance(notMove.transform.position, transform.position) < 12) 
        {
            AttackTimer = 0;
            Attack();
        }
        //左右朝向
        if (notMove.transform.position.x - transform.position.x > 0) 
        {
            rb.transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            rb.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    public void Attack()
    {
        anim.SetTrigger("Attack");
    }
    public void Shoot() 
    {
        Vector3 dir = notMove.transform.position - EmitPos.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var bul = Instantiate(Bullet, EmitPos.transform.position, Quaternion.identity);
        bul.GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x, dir.y).normalized * ShootSpeed;
        if (angle >= -90 && angle <= 90)
        {
            bul.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (angle > 90)
        {
            bul.transform.rotation = Quaternion.Euler(0, 180, -1 * (angle + 180));
        }
        else if (angle < -90)
        {
            bul.transform.rotation = Quaternion.Euler(0, 180, -1 * (angle - 180));
        }

    }

    void FixedUpdate()
    {
        if (notMove != null && Vector2.Distance(notMove.transform.position, transform.position) > 12)
        {
            rb.position = (rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
