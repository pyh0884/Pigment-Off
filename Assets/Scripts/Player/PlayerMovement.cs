﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Cinemachine;
using Rewired;
public class PlayerMovement : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle, walk, attack, death;
    private string currentAnimation;
    private string currentName;
    public float MoveSpeed = 5f;
    float SpeedMultiplier = 1;
    public bool Slowed = false;
    public bool Boost = false;
    private Rigidbody2D rb;
    Vector2 movement;
    public bool isAttacking = false;
    public bool dead = false;
    public float HitBackForce = 5;
    public float HitBackTime = 0.1f;
    private float hitBackTime = 0;
    public float DashSpeed = 40;
    public float DashTime = 0.1f;
    public int DashCount = 0;
    public bool controllable = true;
    private bool isSniper;
    private bool isCannon;
    [HideInInspector] public float MoveTimer = 0;
    public int playerID = 10;
    private Player player;
    Attack atk;
    [HideInInspector] public Transform cursor;

    public void HitBack()
    {
        hitBackTime = 0;
        Vector3 dir = cursor.position - Camera.main.WorldToScreenPoint(transform.position);
        //Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        rb.velocity = new Vector2(dir.x, dir.y).normalized * HitBackForce * -1;
    }
    public void dash()
    {
        DashCount = 3;
    }
    IEnumerator Dash()
    {
        Debug.Log(111);
        DashCount -= 1;
        hitBackTime = 0;
        Vector3 dir = cursor.position - Camera.main.WorldToScreenPoint(transform.position);
        //Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
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
        atk = GetComponentInChildren<Attack>();
        FindObjectOfType<CinemachineTargetGroup>().AddMember(gameObject.transform, 1, 0);
        player = ReInput.players.GetPlayer(playerID);
        currentAnimation = "idle";
        SetCharacterState(currentAnimation);
        rb = GetComponent<Rigidbody2D>();
        isSniper = atk.isSniper;
        isCannon = atk.isCannon;
    }
    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timescale)
    {
        if (animation.name.Equals(currentName))
        {
            return;
        }
        skeletonAnimation.state.SetAnimation(0, animation, loop);
        currentName = animation.name;
    }
    IEnumerator AttackAnim() 
    {
        yield return new WaitForSeconds(0.8f);
        isAttacking = false;
    }
    public void SetCharacterState(string state)
    {   if (state.Equals("die"))
        {
            SetAnimation(death, false, 1f);
        }
        else if (state.Equals("attack"))
        {
            if (isCannon || isSniper)
            {
                SetAnimation(attack, false, 1f);
                StartCoroutine("AttackAnim");
            }
            else 
            {
                SetAnimation(attack, true, 1f);
            }
        }
        else if (state.Equals("idle"))
        {
            SetAnimation(idle, true, 1f);
        }
        else if (state.Equals("walk"))
        {
            SetAnimation(walk, true, 1f);
        }

    } 
    void Update()
    {
        if (player.GetButtonDown("KillPlayer")) 
        {
            GetComponent<HealthBar>().die();
        }
        hitBackTime += Time.deltaTime;
        if (hitBackTime > HitBackTime) 
        {
            rb.velocity = Vector2.zero;
        }
        if (DashCount > 0 && isSniper && player.GetButtonDown("Skill")) 
        {
            StartCoroutine("Dash");
        }
        movement.x = player.GetAxisRaw("MoveHorizontal");
        movement.y = player.GetAxisRaw("MoveVertical");
        SpeedMultiplier = Mathf.Clamp(atk.Mp / atk.MpMax / 2 + 0.5f, 0.5f, 1);
        if (dead)
        {
            SetCharacterState("die");
        }
        else
        {
            if (isAttacking)
            {
                SetCharacterState("attack");
            }
            else
            {
                if (movement.x != 0 || movement.y != 0)
                {
                    SetCharacterState("walk");
                    MoveTimer = 0;
                }
                else
                {
                    SetCharacterState("idle");
                    MoveTimer += Time.deltaTime;
                }
            }
        }
        Vector3 dir = cursor.position - Camera.main.WorldToScreenPoint(transform.position);
        //Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        if (dir.x > 0)
        {
            rb.transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            rb.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    void FixedUpdate()
    {
        if (controllable)
        {
            if (!Slowed)
            {
                rb.position = (rb.position + movement * MoveSpeed * SpeedMultiplier * Time.fixedDeltaTime);
            }
            else if (Slowed)
            {
                rb.position = (rb.position + movement * MoveSpeed / 1.4f * SpeedMultiplier * Time.fixedDeltaTime);
            }
            else if (Boost)
            {
                rb.position = (rb.position + movement * MoveSpeed * 1.4f * SpeedMultiplier * Time.fixedDeltaTime);
            }
        }
    }
    private void OnDestroy()
    {
        FindObjectOfType<CinemachineTargetGroup>().RemoveMember(gameObject.transform);
    }
}
