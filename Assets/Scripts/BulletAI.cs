using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAI : MonoBehaviour
{
    public float ShootSpeed;
    public float LastTime;
    private Rigidbody2D rb;
    public int damage = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,LastTime);
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        rb.velocity =  new Vector2(dir.x, dir.y).normalized * ShootSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<BossHp>().Damage(damage);
        }
    }
    void Update()
    {
    }
}
