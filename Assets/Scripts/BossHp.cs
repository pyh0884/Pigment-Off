using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHp : MonoBehaviour
{
    public float Hp;
    public float TargetHp;
    public float lerpSpeed = 5;
    public float HpMax;
    private Animator anim;
    private bool dead = false;
    //public ParticleSystem ps;
    //private GameManager gm;

    public void Damage(int damageCount)
    {
            //if (damageCount > 0)
            //{
            //    ps.Play();
            //}
            TargetHp -= damageCount;
            TargetHp = Mathf.Clamp(TargetHp, 0, HpMax);            
    }

    void Start()
    {
        //gm = FindObjectOfType<GameManager>();
        Hp = HpMax;
        TargetHp = Hp;
        anim = GetComponent<Animator>();
       
    }
    IEnumerator Die()
    {
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    private void Update()
    {
        Hp = Mathf.Clamp(Hp, 0, HpMax);
        if ((Hp <= 0|| TargetHp<=0) && dead == false)
        {
            // TODO 帧动画事件淡出+destroy 
            // destroy the object or play the dead animation
            dead = true;
            StartCoroutine("Die");
        }
    }

}
