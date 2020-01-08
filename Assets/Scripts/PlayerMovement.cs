using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public bool Slowed = false;
    public bool Boost = false;
    private Rigidbody2D rb;
    Vector2 movement;
    public float HitBackForce = 5;
    public float HitBackTime = 0.1f;
    private float hitBackTime = 0;
    public bool controllable = true;
    private Animator anim;
    public bool CantWalk = false; //普通型1不会走路
    public void HitBack()
    {
        hitBackTime = 0;
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        rb.velocity = new Vector2(dir.x, dir.y).normalized * HitBackForce * -1;
            GetComponentInChildren<Attack>().Shoot();
    }
    public void Paoxie()
    {
        StartCoroutine("PaoXie");
    }
    IEnumerator PaoXie()
    {
        MoveSpeed *= 1.4f;
        yield return new WaitForSeconds(5);
        MoveSpeed /= 1.4f;
    }
    //Top-down Shooting Movement
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        hitBackTime += Time.deltaTime;
        if (hitBackTime > HitBackTime)
        {
            rb.velocity = Vector2.zero;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x != 0||movement.y!=0&&!CantWalk)
        {
            anim.SetBool("Walk",true);
        }
        else
            anim.SetBool("Walk", false);
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        if (dir.x > 0)
        {
            rb.transform.eulerAngles = new Vector3(0,0,0);
        }
        else
        {
            rb.transform.eulerAngles = new Vector3(0,-180,0);
        }
    }
    void FixedUpdate()
    {
        if (controllable)
        {
            if (!Slowed)
            {
                rb.position = (rb.position + movement * MoveSpeed * Time.fixedDeltaTime);
            }
            else if (Slowed)
            {
                rb.position = (rb.position + movement * MoveSpeed / 1.4f * Time.fixedDeltaTime);
            }
            else if (Boost)
            {
                rb.position = (rb.position + movement * MoveSpeed * 1.4f * Time.fixedDeltaTime);
            }
        }
    }

}
