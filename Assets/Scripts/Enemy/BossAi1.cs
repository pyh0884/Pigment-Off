using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using Cinemachine;

public class BossAi1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float AttackGap = 2;
    public float SwitchGap = 7;
    private Vector3 dir;
    private Vector3 dir2;
    private float angle;
    private float angle2;
    public Collider2D notMove;
    public LayerMask enemyLayer;
    public GameObject Emit1;
    public Danmuku danmu1;
    public GameObject Emit2;
    public Danmuku danmu2;
    public float timer1 = 2;
    public float AttackTimer = 10;
    private Vector2 movement;
    public float moveSpeed = 10;
    public bool isAttacking = false;
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle, walk, shoot, death;
    private string currentState;
    public string currentAnimation;
    public string previousState;
    public bool isMoving;
    public AudioSource BossMove;


    void Start()
    {
        FindObjectOfType<CinemachineTargetGroup>().AddMember(gameObject.transform, 1, 0);
        currentState = "idle";
        SetCharacterState(currentState);
        rb = GetComponent<Rigidbody2D>();
        FindNonMove();

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

    public void SetCharacterState(string state)
    {
        if (state.Equals("die"))
        {
            SetAnimation(death, false, 1f);
        }
        else if (state.Equals("shoot"))
        {
            SetAnimation(shoot, true, 1f);
        }
        else if (state.Equals("walk"))
        {
            SetAnimation(walk, true, 1f);
        }
        else if (state.Equals("idle"))
        {
            SetAnimation(idle, true, 1f);
        }
        currentState = state;
    }
    void FindNonMove()
    {
        Collider2D[] list = Physics2D.OverlapCircleAll(transform.position, 100, enemyLayer);
            notMove = list[0];
            foreach (Collider2D col in list)
            {
                if (col.gameObject.GetComponent<PlayerMovement>().MoveTimer + col.gameObject.GetComponentInChildren<Attack>().moveNum >= notMove.gameObject.GetComponent<PlayerMovement>().MoveTimer + notMove.gameObject.GetComponentInChildren<Attack>().moveNum)
                {
                    notMove = col;
                }
            }
    }
    void Update()
    {
        if (currentState == "walk")
        {
            BossMove.mute = false;
        }
        else
        {
            BossMove.mute = true;
        }
        if (!notMove)
        {
            FindNonMove();
        }
        else
        {
            dir = notMove.transform.position - Emit1.transform.position;
            dir2 = notMove.transform.position - Emit2.transform.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            angle2 = Mathf.Atan2(dir2.y, dir2.x) * Mathf.Rad2Deg;
            Emit1.transform.rotation = Quaternion.Euler(0, 0, angle);
            Emit2.transform.rotation = Quaternion.Euler(0, 0, angle2);
            if (Vector2.Distance(notMove.transform.position, transform.position) > 10)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
            movement = new Vector2((notMove.transform.position - transform.position).x, (notMove.transform.position - transform.position).y).normalized;
            //切换目标
            timer1 += Time.deltaTime;
            if (timer1 >= SwitchGap)
            {
                FindNonMove();
                timer1 = 0;
            }
            //攻击间隔
            AttackTimer += Time.deltaTime;
            if (AttackTimer >= AttackGap && !isAttacking)
            {
                isAttacking = true;
                StartCoroutine("attack1");
            }
            //左右朝向
            if (!isAttacking)
            {
                if (notMove.transform.position.x - transform.position.x > 0)
                {
                    rb.transform.eulerAngles = new Vector3(0, -180, 0);
                }
                else
                {
                    rb.transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
        }
    }
    IEnumerator attack1()
    {
        SetCharacterState("idle");
        yield return new WaitForSeconds(1);
        SetCharacterState("shoot");
        danmu1.Shoot();
        danmu2.Shoot();
        yield return new WaitForSeconds(danmu1.AttackGap * 5);
        AttackTimer = 0;
        SetCharacterState("idle");
        yield return new WaitForSeconds(2);
        isAttacking = false;
    }
    void FixedUpdate()
    {
        if (notMove != null && isMoving && !isAttacking)
        {
            rb.position = (rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            SetCharacterState("walk");
        }
        else 
        if (!isMoving && !isAttacking) 
        {
            SetCharacterState("idle");
        }
    }
    private void OnDestroy()
    {
        FindObjectOfType<CinemachineTargetGroup>().RemoveMember(gameObject.transform);
        FindObjectOfType<GameManager>().insBoss2();
    }

}
