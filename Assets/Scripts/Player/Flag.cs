using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Flag : MonoBehaviour
{
    public float hp;
    public float MaxHp;
    private bool dead = false;
    GameManager gm;
    public GameObject flag;
    private Animator anim;
    private bool canMove;
    private Vector3 pos;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dead && collision.gameObject.layer == 12) 
        {
            collision.GetComponentInChildren<Attack>().PickUp();
            anim.SetBool("Get", true);
            pos = collision.gameObject.transform.position;
            MoveTo();
            //Destroy(gameObject);
            //todo:移动到角色头上
        }
    }
    void MoveTo()
    {
        canMove = true;
        transform.position = Vector2.MoveTowards(transform.position, new Vector3(pos.x, pos.y + 2.5f), 5 * Time.deltaTime);
    }
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        MaxHp = Mathf.Clamp(gm.PlayTime * 5 / 9, 1, 100);
        hp = MaxHp;
        anim = GetComponent<Animator>();
    }

    public void Damage(float damageCount)
    {
        //伤害特效 
        if (damageCount > 0 && !dead) 
        {
            hp -= damageCount;
            hp = Mathf.Clamp(hp, 0, MaxHp);
            anim.SetTrigger("Hit");
        }
    }
    public void desSelf() 
    {
        Destroy(gameObject);
    }
    void Update()
    {
        if ((hp <= 0) && !dead)
        {
            dead = true;
            GetComponent<CircleCollider2D>().isTrigger = true;
            gameObject.tag = "Untagged";
        }
        if (canMove)
        {
            MoveTo();
        }
    }
}
