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
        Hp -= damageCount;
    }
    void Start()
    {
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
            // destroy the object or play the dead animation
            dead = true;
            StartCoroutine("Die");
        }
    }
}
