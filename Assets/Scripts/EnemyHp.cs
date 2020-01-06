using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public float Hp;
    public float HpMax;
    private Animator anim;
    private bool dead = false;
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
