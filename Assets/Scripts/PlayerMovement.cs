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
    public float DashSpeed = 40;
    public float DashTime = 0.1f;
    public int DashCount = 0;
    public bool controllable = true;
    private Animator anim;
    public bool CantWalk = false;
    private bool isSniper;
    private bool isCannon;
    public void HitBack()
    {
        hitBackTime = 0;
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        rb.velocity = new Vector2(dir.x, dir.y).normalized * HitBackForce * -1;
    }
    public void dash()
    {
        DashCount = 3;
    }
    IEnumerator Dash()
    {
        DashCount -= 1;
        hitBackTime = 0;
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        rb.velocity = new Vector2(dir.x, dir.y).normalized * DashSpeed;
        yield return new WaitForSeconds(DashTime);
        rb.velocity = Vector2.zero;
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
        MoveSpeed = MoveSpeed;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isSniper = GetComponentInChildren<Attack>().isSniper;
        isCannon = GetComponentInChildren<Attack>().isCannon;
    }
    void Update()
    {
        hitBackTime += Time.deltaTime;
        if (hitBackTime > HitBackTime) 
        {
            rb.velocity = Vector2.zero;
        }
        if (DashCount > 0 && isSniper && Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            StartCoroutine("Dash");
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
