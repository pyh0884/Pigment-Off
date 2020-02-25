using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHp : MonoBehaviour
{
    public bool boss1 = true;
    public float Hp;
    public float HpMax;
    //private Animator anim;
    private bool dead = false;
    //public bool isBoss;
    public bool HitByPlayer = true;      //后续改成判断阵营int
    public GameObject ColorPool1;
    public GameObject ColorPool2;
    public GameObject ColorPool3;
    public GameObject EnemyColorPool2;
    public GameObject EnemyColorPool3;
    public GameObject EnemyColorPool1;
    public float minimumX = 1;
    public float maxmumX = 7;
    public float minimumY = 3;
    public float maxmumY = 10;
    private int ColorType;
    public BossAi1 main;
    public BossAi2 main2;
    public GameObject disappear;
    //public ParticleSystem ps;
    //private GameManager gm;

    public void Damage(int damageCount)
    {
        if (boss1)
        main.SetCharacterState("die");
    else
        main2.SetCharacterState("die");
        Hp -= damageCount;
        Hp = Mathf.Clamp(Hp, 0, HpMax);
        StartCoroutine("back2Idle");
    }
    IEnumerator back2Idle() 
    {
        yield return new WaitForSeconds(0.85f);
        if (boss1)
        {
            if (main.isAttacking)
                main.SetCharacterState("shoot");
            else
                main.SetCharacterState("idle");
        }
        else 
        {
            if (main2.isAttacking)
                main2.SetCharacterState("shoot");
            else
                main2.SetCharacterState("idle");

        }
    }
    void Start()
    {
        Hp = HpMax;
        //anim = GetComponent<Animator>();
    }
    IEnumerator Die()
    {
        if (boss1)
            main.SetCharacterState("die");
        else
            main2.SetCharacterState("die");
        //anim.SetTrigger("Die");
        yield return new WaitForSeconds(0.85f);
        Instantiate(disappear,transform.position,Quaternion.identity);
        //if (isBoss)
        //{
        //    float MinimumX = minimumX / maxmumX;
        //    float MinimumY = minimumY / maxmumY;
        //    if (HitByPlayer)
        //    {
        //        for (int i = 0; i < 5; i++)
        //        {
        //            float rand_VelocityX = -Mathf.Abs(Mathf.Sqrt(-2 * Mathf.Log(Random.value)) * Mathf.Sin(2 * Mathf.PI * Random.value));
        //            float rand_VelocityY = Mathf.Abs(Mathf.Sqrt(-2 * Mathf.Log(Random.value)) * Mathf.Sin(2 * Mathf.PI * Random.value));
        //            ColorType = Mathf.FloorToInt(Random.Range(0, 3));
        //            switch (ColorType)
        //            {
        //                case 0:
        //                    Instantiate(ColorPool1, gameObject.transform.position+ new Vector3((rand_VelocityX * (1 - MinimumX) + MinimumX) * (Random.value > 0.5f ? maxmumX : -maxmumX), (rand_VelocityY * (1 - MinimumY) + MinimumY) * maxmumY), Quaternion.identity);
        //                    break;
        //                case 1:
        //                    Instantiate(ColorPool2, gameObject.transform.position + new Vector3((rand_VelocityX * (1 - MinimumX) + MinimumX) * (Random.value > 0.5f ? maxmumX : -maxmumX), (rand_VelocityY * (1 - MinimumY) + MinimumY) * maxmumY), Quaternion.identity);
        //                    break;
        //                case 2:
        //                    Instantiate(ColorPool3, gameObject.transform.position + new Vector3((rand_VelocityX * (1 - MinimumX) + MinimumX) * (Random.value > 0.5f ? maxmumX : -maxmumX), (rand_VelocityY * (1 - MinimumY) + MinimumY) * maxmumY), Quaternion.identity);
        //                    break;
        //                default:
        //                    Instantiate(ColorPool1, gameObject.transform.position + new Vector3((rand_VelocityX * (1 - MinimumX) + MinimumX) * (Random.value > 0.5f ? maxmumX : -maxmumX), (rand_VelocityY * (1 - MinimumY) + MinimumY) * maxmumY), Quaternion.identity);
        //                    break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < 5; i++)
        //        {
        //            float rand_VelocityX = -Mathf.Abs(Mathf.Sqrt(-2 * Mathf.Log(Random.value)) * Mathf.Sin(2 * Mathf.PI * Random.value));
        //            float rand_VelocityY = Mathf.Abs(Mathf.Sqrt(-2 * Mathf.Log(Random.value)) * Mathf.Sin(2 * Mathf.PI * Random.value));
        //            ColorType = Mathf.FloorToInt(Random.Range(0, 3));
        //            switch (ColorType)
        //            {
        //                case 0:
        //                    Instantiate(EnemyColorPool1, gameObject.transform.position + new Vector3((rand_VelocityX * (1 - MinimumX) + MinimumX) * (Random.value > 0.5f ? maxmumX : -maxmumX), (rand_VelocityY * (1 - MinimumY) + MinimumY) * maxmumY), Quaternion.identity);
        //                    break;
        //                case 1:
        //                    Instantiate(EnemyColorPool2, gameObject.transform.position + new Vector3((rand_VelocityX * (1 - MinimumX) + MinimumX) * (Random.value > 0.5f ? maxmumX : -maxmumX), (rand_VelocityY * (1 - MinimumY) + MinimumY) * maxmumY), Quaternion.identity);
        //                    break;
        //                case 2:
        //                    Instantiate(EnemyColorPool3, gameObject.transform.position + new Vector3((rand_VelocityX * (1 - MinimumX) + MinimumX) * (Random.value > 0.5f ? maxmumX : -maxmumX), (rand_VelocityY * (1 - MinimumY) + MinimumY) * maxmumY), Quaternion.identity);
        //                    break;
        //                default:
        //                    Instantiate(EnemyColorPool1, gameObject.transform.position + new Vector3((rand_VelocityX * (1 - MinimumX) + MinimumX) * (Random.value > 0.5f ? maxmumX : -maxmumX), (rand_VelocityY * (1 - MinimumY) + MinimumY) * maxmumY), Quaternion.identity);
        //                    break;
        //            }
        //        }
        //    }
        //}//爆出颜料        
        Destroy(gameObject);
    }
    private void Update()
    {
        Hp = Mathf.Clamp(Hp, 0, HpMax);
        if ((Hp <= 0) && dead == false)
        {            
            dead = true;
            StartCoroutine("Die");
        }
    }
}
