using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAI : MonoBehaviour
{
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
    public GameObject[] ColorPool1;
    public GameObject[] ColorPool2;
    public GameObject[] ColorPool3;
    public GameObject efx;
    public GameObject efx2;
    public GameObject shadow;
    public int Camp;
    Color camp0 = new Color(0.8f, 0.8666667f, 0.5058824f);//黄色
    Color camp1 = new Color(0.6235294f, 0.5529412f, 0.9137255f);//紫色
    Color camp2 = new Color(0.4313726f, 0.6980392f, 0.6509804f);//蓝色
    public bool isNormal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,Range/ShootSpeed);
    }
    private void Update()
    {
        if (isNormal)
        {
            switch (Camp)
            {
                case 0:
                    GetComponent<SpriteRenderer>().color = camp0;
                    break;
                case 1:
                    GetComponent<SpriteRenderer>().color = camp1;
                    break;
                case 2:
                    GetComponent<SpriteRenderer>().color = camp2;
                    break;
            }
        }
        shadow.transform.localPosition += new Vector3(0,0.6f/(Range / ShootSpeed)*Time.deltaTime,0);
    }
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
            var effect = Instantiate(efx2, transform.position, transform.rotation);//TODO
            effect.GetComponent<EFXColorControl>().camp = Camp;
            Destroy(gameObject);
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
            var effect = Instantiate(efx2, transform.position, transform.rotation);
            var effect = Instantiate(efx2, transform.position, transform.rotation);//TODO
            effect.GetComponent<EFXColorControl>().camp = Camp;
            Destroy(gameObject);
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
            var effect = Instantiate(efx2, transform.position, transform.rotation);
            var effect = Instantiate(efx2, transform.position, transform.rotation);//TODO
            effect.GetComponent<EFXColorControl>().camp = Camp;
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 13) //"Wall" 
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Flag")
        {
            var effect2 = Instantiate(efx2, transform.position, transform.rotation);
            var effect2 = Instantiate(efx2, transform.position, transform.rotation);//TODO
            effect2.GetComponent<EFXColorControl>().camp = Camp;
            collision.GetComponent<Flag>().Damage(damage);
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        if (Camp == 0)
        {
            switch (Mathf.FloorToInt(Random.Range(0, 13.9f)))
            {
                case 0:
                    var bul = Instantiate(ColorPool1[0], gameObject.transform.position, Quaternion.identity);
                    bul.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 1:
                    var bul2 = Instantiate(ColorPool1[1], gameObject.transform.position, Quaternion.identity);
                    bul2.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 2:
                    var bul3 = Instantiate(ColorPool1[2], gameObject.transform.position, Quaternion.identity);
                    bul3.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 3:
                    var bul4 = Instantiate(ColorPool1[3], gameObject.transform.position, Quaternion.identity);
                    bul4.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 4:
                    var bul5 = Instantiate(ColorPool1[4], gameObject.transform.position, Quaternion.identity);
                    bul5.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 5:
                    var bul6 = Instantiate(ColorPool1[5], gameObject.transform.position, Quaternion.identity);
                    bul6.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 6:
                    var bul7 = Instantiate(ColorPool1[6], gameObject.transform.position, Quaternion.identity);
                    bul7.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 7:
                    var bul8 = Instantiate(ColorPool1[7], gameObject.transform.position, Quaternion.identity);
                    bul8.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 8:
                    var bul9 = Instantiate(ColorPool1[8], gameObject.transform.position, Quaternion.identity);
                    bul9.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 9:
                    var bul10 = Instantiate(ColorPool1[9], gameObject.transform.position, Quaternion.identity);
                    bul10.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 10:
                    var bul11 = Instantiate(ColorPool1[10], gameObject.transform.position, Quaternion.identity);
                    bul11.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 11:
                    var bul12 = Instantiate(ColorPool1[11], gameObject.transform.position, Quaternion.identity);
                    bul12.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 12:
                    var bul13 = Instantiate(ColorPool1[12], gameObject.transform.position, Quaternion.identity);
                    bul13.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 13:
                    var bul14 = Instantiate(ColorPool1[13], gameObject.transform.position, Quaternion.identity);
                    bul14.GetComponent<ColorPool>().Camp = Camp;
                    break;
                default:
                    var bul15 = Instantiate(ColorPool1[0], gameObject.transform.position, Quaternion.identity);
                    bul15.GetComponent<ColorPool>().Camp = Camp;
                    break;
            }
        }
        if (Camp == 1)
        {
            switch (Mathf.FloorToInt(Random.Range(0, 13.9f)))
            {
                case 0:
                    var bul = Instantiate(ColorPool2[0], gameObject.transform.position, Quaternion.identity);
                    bul.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 1:
                    var bul2 = Instantiate(ColorPool2[1], gameObject.transform.position, Quaternion.identity);
                    bul2.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 2:
                    var bul3 = Instantiate(ColorPool2[2], gameObject.transform.position, Quaternion.identity);
                    bul3.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 3:
                    var bul4 = Instantiate(ColorPool2[3], gameObject.transform.position, Quaternion.identity);
                    bul4.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 4:
                    var bul5 = Instantiate(ColorPool2[4], gameObject.transform.position, Quaternion.identity);
                    bul5.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 5:
                    var bul6 = Instantiate(ColorPool2[5], gameObject.transform.position, Quaternion.identity);
                    bul6.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 6:
                    var bul7 = Instantiate(ColorPool2[6], gameObject.transform.position, Quaternion.identity);
                    bul7.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 7:
                    var bul8 = Instantiate(ColorPool2[7], gameObject.transform.position, Quaternion.identity);
                    bul8.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 8:
                    var bul9 = Instantiate(ColorPool2[8], gameObject.transform.position, Quaternion.identity);
                    bul9.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 9:
                    var bul10 = Instantiate(ColorPool2[9], gameObject.transform.position, Quaternion.identity);
                    bul10.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 10:
                    var bul11 = Instantiate(ColorPool2[10], gameObject.transform.position, Quaternion.identity);
                    bul11.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 11:
                    var bul12 = Instantiate(ColorPool2[11], gameObject.transform.position, Quaternion.identity);
                    bul12.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 12:
                    var bul13 = Instantiate(ColorPool2[12], gameObject.transform.position, Quaternion.identity);
                    bul13.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 13:
                    var bul14 = Instantiate(ColorPool2[13], gameObject.transform.position, Quaternion.identity);
                    bul14.GetComponent<ColorPool>().Camp = Camp;
                    break;
                default:
                    var bul15 = Instantiate(ColorPool2[0], gameObject.transform.position, Quaternion.identity);
                    bul15.GetComponent<ColorPool>().Camp = Camp;
                    break;
            }
        }
        if (Camp == 2)
        {
            switch (Mathf.FloorToInt(Random.Range(0, 13.9f)))
            {
                case 0:
                    var bul = Instantiate(ColorPool3[0], gameObject.transform.position, Quaternion.identity);
                    bul.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 1:
                    var bul2 = Instantiate(ColorPool3[1], gameObject.transform.position, Quaternion.identity);
                    bul2.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 2:
                    var bul3 = Instantiate(ColorPool3[2], gameObject.transform.position, Quaternion.identity);
                    bul3.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 3:
                    var bul4 = Instantiate(ColorPool3[3], gameObject.transform.position, Quaternion.identity);
                    bul4.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 4:
                    var bul5 = Instantiate(ColorPool3[4], gameObject.transform.position, Quaternion.identity);
                    bul5.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 5:
                    var bul6 = Instantiate(ColorPool3[5], gameObject.transform.position, Quaternion.identity);
                    bul6.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 6:
                    var bul7 = Instantiate(ColorPool3[6], gameObject.transform.position, Quaternion.identity);
                    bul7.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 7:
                    var bul8 = Instantiate(ColorPool3[7], gameObject.transform.position, Quaternion.identity);
                    bul8.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 8:
                    var bul9 = Instantiate(ColorPool3[8], gameObject.transform.position, Quaternion.identity);
                    bul9.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 9:
                    var bul10 = Instantiate(ColorPool3[9], gameObject.transform.position, Quaternion.identity);
                    bul10.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 10:
                    var bul11 = Instantiate(ColorPool3[10], gameObject.transform.position, Quaternion.identity);
                    bul11.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 11:
                    var bul12 = Instantiate(ColorPool3[11], gameObject.transform.position, Quaternion.identity);
                    bul12.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 12:
                    var bul13 = Instantiate(ColorPool3[12], gameObject.transform.position, Quaternion.identity);
                    bul13.GetComponent<ColorPool>().Camp = Camp;
                    break;
                case 13:
                    var bul14 = Instantiate(ColorPool3[13], gameObject.transform.position, Quaternion.identity);
                    bul14.GetComponent<ColorPool>().Camp = Camp;
                    break;
                default:
                    var bul15 = Instantiate(ColorPool3[0], gameObject.transform.position, Quaternion.identity);
                    bul15.GetComponent<ColorPool>().Camp = Camp;
                    break;
            }
        }

        if (efx)
        {
            var effect = Instantiate(efx, gameObject.transform.position, Quaternion.identity);
            switch (Camp)
            {
                case 0:
                    effect.GetComponent<ParticleSystem>().startColor = camp0;
                    break;
                case 1:
                    effect.GetComponent<ParticleSystem>().startColor = camp1;
                    break;
                case 2:
                    effect.GetComponent<ParticleSystem>().startColor = camp2;
                    break;
            }

        }
    }
}
