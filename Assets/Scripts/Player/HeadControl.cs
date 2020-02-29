using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class HeadControl : MonoBehaviour
{
    private Vector3 dir;
    private float angle;

    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle, attack, death, target, walk;
    private string currentState;
    [HideInInspector] public string currentAnimation;
    [HideInInspector] public string previousState;
    public bool dead;
    public bool isTarget;
    public bool isAttacking;
    public float AttackTime = 0.25f;
    [HideInInspector] public Transform cursor;
    void Start()
    {
        currentState = "idle";
        SetCharacterState(currentState);
    }
    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timescale)
    {
        if (animation.name.Equals(currentAnimation))
        {
            return;
        }
        skeletonAnimation.state.SetAnimation(0, animation, loop);
        currentAnimation = animation.name;
    }
    public void RotateHead() 
    {
        dir = cursor.position- Camera.main.WorldToScreenPoint(transform.position);
        //dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (dir.x < 0)
        {
            //GunSprite.transform.rotation = Quaternion.Euler(180, 0, -angle);
            if (dir.y > 0)
                transform.rotation = Quaternion.Euler(180, 180, Mathf.Clamp(angle, 150, 180));
            else
            {
                transform.rotation = Quaternion.Euler(180, 180, Mathf.Clamp(angle, -180, -150));
            }
        }
        else
        {
            //GunSprite.transform.rotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Euler(0, 180, -Mathf.Clamp(angle, -30, 30));
        }

    }
    public void SetCharacterState(string state)
    {
        if (state.Equals("die"))
        {
            SetAnimation(death, false, 1f);
        }
        else if (state.Equals("target"))
        {
            SetAnimation(target, false, 1f);
        }
        else if (state.Equals("attack"))
        {               
            SetAnimation(attack, true, 1f);
        }
        else if (state.Equals("idle"))
        {
            SetAnimation(idle, true, 1f);
        }
        else if (state.Equals("walk"))
        {
            SetAnimation(walk, true, 1f);
        }
        currentState = state;
    }
    IEnumerator resetAnim() //0.4s
    {
        yield return new WaitForSeconds(AttackTime);
        isTarget = false;
        isAttacking = false;

    }
    // Update is called once per frame
    void Update()
    {
        #region Animation
        if (dead)
        {
            SetCharacterState("die");
        }
        else
        {
            if (isTarget && !isAttacking)
            {
                SetCharacterState("target");
            }
            else if (isTarget && isAttacking)
            {
                SetCharacterState("attack");
                StartCoroutine("resetAnim");
            }
            else
            {
                if (Input.GetAxisRaw("Horizontal")!=0|| Input.GetAxisRaw("Vertical")!=0)
                {
                    SetCharacterState("walk");
                }
                else
                {
                    SetCharacterState("idle");
                }
            }
        }
        #endregion
        RotateHead();
    }
}