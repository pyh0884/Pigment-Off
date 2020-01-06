using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float Hp = 100;
    public float HpMax = 100;
    public int IncreaseHp;
    private Animator anim;
    public GameManager gm;
    public bool cheat;
    public float TargetHp = 100;
    public float lerpSpeed = 5;
    public float lerpSpeed2 = 5;
    void Awake()
    {
        Hp = HpMax;
        TargetHp = HpMax;
        gm = FindObjectOfType<GameManager>();
        //Hp = gm.HP;
        //HpMax = gm.MAXHP;
        currentHealth();
        anim = GetComponent<Animator>();
        GetComponentInChildren<Canvas>().worldCamera = FindObjectOfType<Camera>();
    }

    public void Damage(int damageCount)
    {
        //伤害特效 
        //       FindObjectOfType<AudioManager>().Play("Player_Hit");
        //       anim.SetTrigger("Hit");
        if (damageCount < 0)
        {
            TargetHp -= damageCount;
            TargetHp = Mathf.Clamp(TargetHp, 0, HpMax);
            //currentHealth();

        }//回血特效 
        if (damageCount > 0)
        {
            if (!cheat)
            {
                TargetHp -= damageCount;
                //anim.SetTrigger("Hit");
            }
            TargetHp = Mathf.Clamp(TargetHp, 0, HpMax);
            //currentHealth();
        }
    }
    
    public void IncreaseMax()
    {
        HpMax += IncreaseHp;
        TargetHp += IncreaseHp + 20;
    }

    void currentHealth()
    {
        if (TargetHp <= 0 || Hp <= 0)
        {
            StartCoroutine("Die");
        }
        if (TargetHp < Hp)
        {
            Hp = Mathf.Lerp(Hp, TargetHp, Time.deltaTime * lerpSpeed);
        }
        else
        {
            Hp = Mathf.Lerp(Hp, TargetHp, Time.deltaTime * lerpSpeed2);
        }
        slider.value = (float)(Hp / HpMax);
    }

    IEnumerator Die()
    {
        GetComponent<PlayerMovement>().controllable = false;
        GetComponentInChildren<Attack>().CanAttack = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        Time.timeScale = 1;
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        //gm.Respawn();
    }
    private void Update()
    {
        //HpMax = gm.MAXHP;
        currentHealth();
    }
}
