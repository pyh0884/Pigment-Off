using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //public bool isEnemy;
    //public bool fromBoss;
    //Collider2D nearest;
    //Collider2D nearest2;
    //public LayerMask enemyLayer; //敌人AI使用
    [Header("射速")]
    public float ShootSpeed;
    [Header("射程")]
    public float Range = 30;
    private Rigidbody2D rb;
    [Header("子弹的伤害")]
    public int damage = 10;
    public GameObject ColorPool1;
    public GameObject ColorPool2;
    public GameObject ColorPool3;
    private int ColorType;
    public GameObject efx;
    public GameObject shadow;
    void Start()
    {
        ColorType = Mathf.FloorToInt(Random.Range(0, 2.9f));
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, Range / ShootSpeed);
        //if (isEnemy)
        //{
        //    FindEnemy();
        //    Vector3 dir = nearest2.transform.position - transform.position;
        //    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //    rb.velocity = dir.normalized * ShootSpeed;
        //}
    }

    //void FindEnemy()
    //{
    //    Collider2D[] list = Physics2D.OverlapCircleAll(transform.position, 150, enemyLayer);
    //        nearest = list[0];
    //        nearest2 = list[0];
    //        foreach (Collider2D col in list)
    //        {
    //            if (Vector2.Distance(new Vector2(col.transform.position.x, col.transform.position.y), new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)) <= Vector2.Distance(new Vector2(nearest.transform.position.x, nearest.transform.position.y), new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)))
    //            {
    //                nearest2 = nearest;
    //                nearest = col;
    //            }
    //        }
    //    if (nearest == nearest2) { nearest2 = list[1]; }
    //}
    private void Update()
    {
        shadow.transform.localPosition += new Vector3(0, 0.6f / (Range / ShootSpeed) * Time.deltaTime, 0);
        //shadow.transform.localPosition = new Vector3(1.098f, Mathf.Clamp(shadow.transform.localPosition.y, -1.5f, -0.5f));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12) //"Player"
        {
            collision.GetComponent<HealthBar>().Damage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 13) //"Wall"
        {
            Destroy(collision.gameObject);
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
        if (efx)
        {
            Instantiate(efx, gameObject.transform.position, Quaternion.identity);
        }
    }

}
