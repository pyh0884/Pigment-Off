using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonExplosion : MonoBehaviour
{
    [Header("射速")]
    public float ShootSpeed;
    [Header("射程")]
    public float Range = 30;
    private Rigidbody2D rb;
    [Header("子弹的伤害")]
    public int damage = 10;
    [Header("暴击率")]
    [Range(0, 100)]
    public float CritPos = 0;
    [Header("暴击伤害百分比")]
    public int CritDmgMultiplier = 150;
    public float ExpRange = 1;
    public GameObject main;
    public GameObject efx2;
    public int Camp;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Destroy(gameObject, Range / ShootSpeed);
    }
    private void Update()
    {
        GetComponent<CircleCollider2D>().radius = ExpRange;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //Instantiate(spr, transform.position, Quaternion.identity);
            if (Random.Range(0, 100) < CritPos)
            {
                collision.GetComponent<EnemyHp>().Damage(damage * CritDmgMultiplier / 100);
            }
            else
            {
                collision.GetComponent<EnemyHp>().Damage(damage);
            }
            var effect = Instantiate(efx2, transform.position, transform.rotation);//TODO
            effect.GetComponent<EFXColorControl>().camp = Camp;
            Destroy(main);
        }
        if (collision.tag == "Boss")
        {
            //Instantiate(spr, transform.position, Quaternion.identity);
            if (Random.Range(0, 100) < CritPos)
            {
                collision.GetComponent<BossHp>().Damage(damage * CritDmgMultiplier / 100);
            }
            else
            {
                collision.GetComponent<BossHp>().Damage(damage);
            }
            collision.GetComponent<BossHp>().HitByPlayer = true;
            var effect = Instantiate(efx2, transform.position, transform.rotation);
            effect.GetComponent<EFXColorControl>().camp = Camp;
            Destroy(main);
        }
        if (collision.gameObject.layer == 12 && collision.GetComponentInChildren<Attack>().Camp != gameObject.transform.parent.GetComponent<CannonBullet>().Camp)
        {
            if (Random.Range(0, 100) < CritPos)
            {
                collision.GetComponent<HealthBar>().Damage(damage * CritDmgMultiplier / 100);
            }
            else
            {
                collision.GetComponent<HealthBar>().Damage(damage);
            }
            var effect = Instantiate(efx2, transform.position, transform.rotation);
            effect.GetComponent<EFXColorControl>().camp = Camp;
            Destroy(main);
        }
        if (collision.tag == "Flag" && collision.GetComponent<Flag>())
        {
            collision.GetComponent<Flag>().Damage(damage);
            var effect = Instantiate(efx2, transform.position, transform.rotation);
            effect.GetComponent<EFXColorControl>().camp = Camp;
            Destroy(main);
        }
    }

}
