using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHp : MonoBehaviour
{
    public float Hp;
    public float HpMax;
    private Animator anim;
    private bool dead = false;
    public bool isBoss;
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
    //public ParticleSystem ps;
    //private GameManager gm;

    public void Damage(int damageCount)
    {
        //if (damageCount > 0)
        //{
        //    ps.Play();
        //}
        Hp -= damageCount;
        Hp = Mathf.Clamp(Hp, 0, HpMax);            
    }

    void Start()
    {
        //gm = FindObjectOfType<GameManager>();
        Hp = HpMax;
        anim = GetComponent<Animator>();
        
    }
    IEnumerator Die()
    {
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(1);
        if (isBoss)
        {
            float MinimumX = minimumX / maxmumX;
            float MinimumY = minimumY / maxmumY;
            if (HitByPlayer)
            {
                for (int i = 0; i < 5; i++)
                {
                    float rand_VelocityX = -Mathf.Abs(Mathf.Sqrt(-2 * Mathf.Log(Random.value)) * Mathf.Sin(2 * Mathf.PI * Random.value));
                    float rand_VelocityY = Mathf.Abs(Mathf.Sqrt(-2 * Mathf.Log(Random.value)) * Mathf.Sin(2 * Mathf.PI * Random.value));
                    ColorType = Mathf.FloorToInt(Random.Range(0, 3));
                    switch (ColorType)
                    {
                        case 0:
                            Instantiate(ColorPool1, gameObject.transform.position+ new Vector3((rand_VelocityX * (1 - MinimumX) + MinimumX) * (Random.value > 0.5f ? maxmumX : -maxmumX), (rand_VelocityY * (1 - MinimumY) + MinimumY) * maxmumY), Quaternion.identity);
                            break;
                        case 1:
                            Instantiate(ColorPool2, gameObject.transform.position + new Vector3((rand_VelocityX * (1 - MinimumX) + MinimumX) * (Random.value > 0.5f ? maxmumX : -maxmumX), (rand_VelocityY * (1 - MinimumY) + MinimumY) * maxmumY), Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(ColorPool3, gameObject.transform.position + new Vector3((rand_VelocityX * (1 - MinimumX) + MinimumX) * (Random.value > 0.5f ? maxmumX : -maxmumX), (rand_VelocityY * (1 - MinimumY) + MinimumY) * maxmumY), Quaternion.identity);
                            break;
                        default:
                            Instantiate(ColorPool1, gameObject.transform.position + new Vector3((rand_VelocityX * (1 - MinimumX) + MinimumX) * (Random.value > 0.5f ? maxmumX : -maxmumX), (rand_VelocityY * (1 - MinimumY) + MinimumY) * maxmumY), Quaternion.identity);
                            break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    float rand_VelocityX = -Mathf.Abs(Mathf.Sqrt(-2 * Mathf.Log(Random.value)) * Mathf.Sin(2 * Mathf.PI * Random.value));
                    float rand_VelocityY = Mathf.Abs(Mathf.Sqrt(-2 * Mathf.Log(Random.value)) * Mathf.Sin(2 * Mathf.PI * Random.value));
                    ColorType = Mathf.FloorToInt(Random.Range(0, 3));
                    switch (ColorType)
                    {
                        case 0:
                            Instantiate(EnemyColorPool1, gameObject.transform.position + new Vector3((rand_VelocityX * (1 - MinimumX) + MinimumX) * (Random.value > 0.5f ? maxmumX : -maxmumX), (rand_VelocityY * (1 - MinimumY) + MinimumY) * maxmumY), Quaternion.identity);
                            break;
                        case 1:
                            Instantiate(EnemyColorPool2, gameObject.transform.position + new Vector3((rand_VelocityX * (1 - MinimumX) + MinimumX) * (Random.value > 0.5f ? maxmumX : -maxmumX), (rand_VelocityY * (1 - MinimumY) + MinimumY) * maxmumY), Quaternion.identity);
                            break;
                        case 2:
                            Instantiate(EnemyColorPool3, gameObject.transform.position + new Vector3((rand_VelocityX * (1 - MinimumX) + MinimumX) * (Random.value > 0.5f ? maxmumX : -maxmumX), (rand_VelocityY * (1 - MinimumY) + MinimumY) * maxmumY), Quaternion.identity);
                            break;
                        default:
                            Instantiate(EnemyColorPool1, gameObject.transform.position + new Vector3((rand_VelocityX * (1 - MinimumX) + MinimumX) * (Random.value > 0.5f ? maxmumX : -maxmumX), (rand_VelocityY * (1 - MinimumY) + MinimumY) * maxmumY), Quaternion.identity);
                            break;
                    }
                }
            }
        }
        
        Destroy(gameObject);
    }
    private void Update()
    {
        Hp = Mathf.Clamp(Hp, 0, HpMax);
        if ((Hp <= 0) && dead == false)
        {
            // TODO 帧动画事件淡出+destroy 
            // destroy the object or play the dead animation
            dead = true;
            StartCoroutine("Die");
        }
    }

}
