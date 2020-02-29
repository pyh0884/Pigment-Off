using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPool : MonoBehaviour
{
    public float IncreaseShootingSpd = 1.5f;
    private float Timer = 0.5f;
    public float HpRecoverSpeed = 5;
    public int Camp;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12 && Timer > 1 && collision.GetComponentInChildren<Attack>().Camp == Camp)//Todo:区分自己的颜料 阵营参数
        {
            collision.GetComponent<HealthBar>().Damage(-HpRecoverSpeed);
            Timer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12 && (collision.tag == "Normal1" || collision.tag == "Normal2") && collision.GetComponentInChildren<Attack>().Camp == Camp) 
        {
            collision.GetComponentInChildren<Attack>().MpBoost = true;
            collision.GetComponentInChildren<Attack>().CdTime = collision.GetComponentInChildren<Attack>().tempCD / IncreaseShootingSpd;
        }
        if (collision.gameObject.layer == 12 && (collision.tag == "Sniper1" || collision.tag == "Sniper2") && collision.GetComponentInChildren<Attack>().Camp == Camp)
        {
            collision.GetComponentInChildren<Attack>().MpBoost = true;
            collision.GetComponent<PlayerMovement>().Boost = true;
        }
        if (collision.gameObject.layer == 12 && (collision.tag == "Cannon1" || collision.tag == "Cannon2") && collision.GetComponentInChildren<Attack>().Camp == Camp)
        {
            collision.GetComponentInChildren<Attack>().expRange = 2;
            collision.GetComponentInChildren<Attack>().MpBoost = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12 && (collision.tag == "Normal1" || collision.tag == "Normal2") && collision.GetComponentInChildren<Attack>().Camp == Camp)
        {
            collision.GetComponentInChildren<Attack>().MpBoost = false;
            collision.GetComponentInChildren<Attack>().CdTime = collision.GetComponentInChildren<Attack>().tempCD;
        }
        if (collision.gameObject.layer == 12 && (collision.tag == "Sniper1" || collision.tag == "Sniper2") && collision.GetComponentInChildren<Attack>().Camp == Camp)
        {
            collision.GetComponentInChildren<Attack>().MpBoost = false;
            collision.GetComponent<PlayerMovement>().Boost = false;
        }
        if (collision.gameObject.layer == 12 && (collision.tag == "Cannon1" || collision.tag == "Cannon2") && collision.GetComponentInChildren<Attack>().Camp == Camp)
        {
            collision.GetComponentInChildren<Attack>().expRange = 1;
            collision.GetComponentInChildren<Attack>().MpBoost = false;
        }

    }
    void Start()
    {
        Destroy(gameObject, 6);
    }
    private void Update()
    {
        Timer += Time.deltaTime;
    }
}
