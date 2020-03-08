using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
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
    public GameObject efx2;
    public GameObject shadow;
    public bool isBoss;
    void Start()
    {
        ColorType = Mathf.FloorToInt(Random.Range(0, 2.9f));
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, Range / ShootSpeed);
    }
    private void Update()
    {
        shadow.transform.localPosition += new Vector3(0, 0.6f / (Range / ShootSpeed) * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12) //"Player"
        {
            collision.GetComponent<HealthBar>().Damage(damage);
            Instantiate(efx2, transform.position, transform.rotation);//TODO
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 13) //"Wall"
        {
            if (isBoss)
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
            var effect = Instantiate(efx, gameObject.transform.position, Quaternion.identity);
            effect.GetComponent<ParticleSystem>().startColor = new Color(0, 0, 0);
        }
    }
}
