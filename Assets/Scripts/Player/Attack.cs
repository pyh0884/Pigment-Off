﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using Rewired;
public class Attack : MonoBehaviour
{
    #region Parameters
    //Sniper

    [Header("狙击角色：")]
    public bool isSniper;
    [Header("瞄准速度")]
    public float AimingSpeed = 5;
    [Header("瞄准时消耗颜料/帧")]
    public float AimingCost = 0.2f;
    public LayerMask BlockRay;
    public LineRenderer laserLeft;
    public LineRenderer laserRight;
    private RaycastHit2D LeftHit;
    private RaycastHit2D RightHit;
    private bool pressed = false;
    private bool StartAiming;
    private Vector3 EndPoint;
    private Vector3 LeftPoint;
    private Vector3 RightPoint;
    private Vector3 RandomDir;
    public float SkillCd2 = 20;
    private float skillCd2 = 20;
    //--------------------------------
    //Cannon
    [Header("重炮角色：")]
    public bool isCannon;
    public LineRenderer TrajectoryLine;
    private bool CannonAiming = false;
    private bool CannonPressed = false;
    public float minDamage = 10;
    public float maxDamage = 40;
    public bool BoostCannon;
    public float SkillCd3 = 20;
    private float skillCd3 = 20;
    public float expRange = 1;
    //--------------------------------
    //Basic Attack Parameters
    [Header("基本参数：")]
    public SkeletonAnimation skeletonAnimation;
    public SkeletonAnimation skeletonAnimation2;
    public AnimationReferenceAsset idle, shoot, death, target;
    private string currentState;
    public string currentAnimation;
    public string previousState;
    private Vector3 dir;
    private Vector3 dir2;
    private float angle;
    private float angle2;
    public GameObject GunSprite;
    public GameObject EmitPoint;
    public GameObject EmitPoint2;
    public GameObject Bullet;
    [Header("攻击间隔")]
    public float CdTime;
    private float cdTime = 10;
    public float SkillCd1 = 20;
    private float skillCd1 = 20;
    [HideInInspector]
    public float tempCD;
    private Vector3 rotation;
    public Slider slider;
    public float Mp = 100;
    [Header("最大颜料值")]
    public float MpMax = 100;
    public float TargetMp = 100;
    public float lerpSpeed = 5;
    [Header("颜料增长速度")]
    public float MpIncreaseSpeed = 5;
    [Header("回复速度提高倍率")]
    public bool MpBoost = false;
    public float MpBoostNum = 3;
    [Header("回复速度降低倍率")]
    public bool MpSlow = false;
    public float MpSlowNum = 3;
    [Header("每发子弹颜料消耗")]
    public int MpCost = 10;
    public bool CanAttack = true; 
    public GameObject main;
    public bool dead;
    private float AttackTimer;
    private float SkillTimer;
    public int moveNum;
    public int playerID = 0;
    [SerializeField] private Player player;
    #endregion
    public void KeLe()
    {
        StartCoroutine("Kele");
    }
    IEnumerator Kele()
    {
        MpIncreaseSpeed *= 1.4f;
        yield return new WaitForSeconds(5);
        MpIncreaseSpeed /= 1.4f;
    }
    IEnumerator SkillBoost1()
    {
        SkillTimer = 0;
        MpIncreaseSpeed *= 3;
        CdTime /= 2;
        yield return new WaitForSeconds(8);
        MpIncreaseSpeed /= 3;
        CdTime *= 2;
    }
    IEnumerator SkillBoost2()
    {
        Debug.Log("Skill");
        SkillTimer = 0;
        MpIncreaseSpeed *= 3;
        main.GetComponent<PlayerMovement>().dash();
        yield return new WaitForSeconds(8);
        MpIncreaseSpeed /= 3;
    }
    IEnumerator SkillBoost3()
    {
        SkillTimer = 0;
        MpIncreaseSpeed *= 3;
        main.GetComponent<HealthBar>().Shield = true;
        CannonSkill = true;
        yield return new WaitForSeconds(8);
        CannonSkill = false;
        main.GetComponent<HealthBar>().Shield = false;
        MpIncreaseSpeed /= 3;
    }
    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
        currentState = "idle";
        SetCharacterState(currentState);
        cdTime = 10;
        tempCD = CdTime;
    }
    public void SetAnimation(AnimationReferenceAsset animation, bool loop, float timescale)
    {
        if (animation.name.Equals(currentAnimation))
        {
            return;
        }
        skeletonAnimation.state.SetAnimation(0, animation, loop);
        if (skeletonAnimation2) 
        {
        skeletonAnimation2.state.SetAnimation(0, animation, loop);
        }
        currentAnimation = animation.name;
    }

    public void SetCharacterState(string state)
    {
        if (state.Equals("die"))
        {
            SetAnimation(death, false, 1f);
        }
        else if (state.Equals("target"))
        {
            SetAnimation(target, true, 1f);
        }
        else if (state.Equals("shoot"))
        {
            SetAnimation(shoot, false, 1f);
        }
        else if (state.Equals("idle"))
        {
            SetAnimation(idle, true, 1f);
        }

        currentState = state;
    }

    public void Shoot() //普通型攻击
    {
        AttackTimer = 0;
        NormalShooting = true;
        var bul = Instantiate(Bullet, EmitPoint.transform.position, Quaternion.identity);
        var bul2 = Instantiate(Bullet, EmitPoint2.transform.position, Quaternion.identity);
        if (Mathf.Sqrt(Mathf.Pow(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x, 2) + Mathf.Pow(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, 2)) < 12) 
        {
            //Debug.Log(Mathf.Sqrt(Mathf.Pow(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x, 2) + Mathf.Pow(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, 2)));
            bul.GetComponent<BulletAI>().Range = Mathf.Sqrt(Mathf.Pow(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x, 2) + Mathf.Pow(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, 2));
            bul2.GetComponent<BulletAI>().Range = Mathf.Sqrt(Mathf.Pow(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x, 2) + Mathf.Pow(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, 2));
        }
        bul.GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x, dir.y).normalized * bul.GetComponent<BulletAI>().ShootSpeed;
        bul2.GetComponent<Rigidbody2D>().velocity = new Vector2(dir2.x, dir2.y).normalized * bul2.GetComponent<BulletAI>().ShootSpeed;
        if (angle >= -90 && angle <= 90)
        {
            bul.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        else if (angle > 90)
        {
            bul.transform.rotation = Quaternion.Euler(0, 180, -1 * (angle + 180));
        }
        else if (angle < -90)
        {
            bul.transform.rotation = Quaternion.Euler(0, 180, -1 * (angle - 180));
        }
        if (angle2 >= -90 && angle2 <= 90)
        {
            bul2.transform.rotation = Quaternion.Euler(0, 0, angle2);
        }
        else if (angle2 > 90)
        {
            bul2.transform.rotation = Quaternion.Euler(0, 180, -1 * (angle2 + 180));
        }
        else if (angle2 < -90)
        {
            bul2.transform.rotation = Quaternion.Euler(0, 180, -1 * (angle2 - 180));
        }
        //bul.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, Vector3.forward);

        cdTime = 0;
        TargetMp = Mp - MpCost;
        TargetMp = Mathf.Clamp(TargetMp, 0, MpMax);
    }
    IEnumerator waitFor4()
    {
        yield return new WaitForSeconds(0.4f);
        SetCharacterState("idle");
    }
    IEnumerator waitFor5()
    {
        yield return new WaitForSeconds(0.5f);
        SetCharacterState("idle");
    }
    public void SniperAiming()
    {
        if (!currentState.Equals("shoot"))
        {
            SetCharacterState("target");
        }            
        TargetMp -= AimingCost;
        TargetMp = Mathf.Clamp(TargetMp, 0, MpMax);
        laserLeft.SetPosition(0, EmitPoint.transform.position);
        laserRight.SetPosition(0, EmitPoint.transform.position);
        EndPoint = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - EmitPoint.transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - EmitPoint.transform.position.y, 0);
        if (!pressed)
        {
            TargetMp = Mp - MpCost;
            LeftPoint = new Vector3(-1 * EndPoint.y, EndPoint.x, 0);
            RightPoint = new Vector3(EndPoint.y, -1 * EndPoint.x, 0);
            pressed = true;
            laserLeft.enabled = true;
            laserRight.enabled = true;
        }
        /*
         * //如果狙击瞄准线不受掩体阻挡
         * laserLeft.SetPosition(1, EmitPoint.transform.position + LeftPoint.normalized * 20);
         * laserRight.SetPosition(1, EmitPoint.transform.position + RightPoint.normalized * 20);  
         * LeftPoint = Vector3.Lerp(LeftPoint, EndPoint, AimingSpeed * Time.deltaTime);
         * RightPoint = Vector3.Lerp(RightPoint, EndPoint, AimingSpeed * Time.deltaTime);        
         */
        LeftHit = Physics2D.Raycast(EmitPoint.transform.position, LeftPoint, 20, BlockRay);
        RightHit = Physics2D.Raycast(EmitPoint.transform.position, RightPoint, 20, BlockRay);
        if (LeftHit)
        {
            laserLeft.SetPosition(1, LeftHit.point);
        }
        else
        {
            laserLeft.SetPosition(1, EmitPoint.transform.position + LeftPoint.normalized * 20);
        }
        if (RightHit)
        {
            laserRight.SetPosition(1, RightHit.point);
        }
        else
        {
            laserRight.SetPosition(1, EmitPoint.transform.position + RightPoint.normalized * 20);
        }
        LeftPoint = Vector3.Lerp(LeftPoint, EndPoint, AimingSpeed * Time.deltaTime);
        RightPoint = Vector3.Lerp(RightPoint, EndPoint, AimingSpeed * Time.deltaTime);
    }
    public void SniperShoot()
    {
        AttackTimer = 0;
        StartAiming = false;
        laserLeft.enabled = false;
        laserRight.enabled = false;
        pressed = false;
        RandomDir = (EmitPoint.transform.position + LeftPoint + (RightPoint - LeftPoint).normalized * Random.Range(0, (RightPoint - LeftPoint).magnitude)) - EmitPoint.transform.position;
        var bul = Instantiate(Bullet, EmitPoint.transform.position, Quaternion.identity);
        bul.GetComponent<Rigidbody2D>().velocity = new Vector2(RandomDir.x, RandomDir.y).normalized * bul.GetComponent<BulletAI>().ShootSpeed;
        //bul.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(RandomDir.y, RandomDir.x) * Mathf.Rad2Deg, Vector3.forward);
        if (Mathf.Atan2(RandomDir.y, RandomDir.x) * Mathf.Rad2Deg >= -90 && Mathf.Atan2(RandomDir.y, RandomDir.x) * Mathf.Rad2Deg <= 90)
        {
            bul.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(RandomDir.y, RandomDir.x) * Mathf.Rad2Deg);
        }
        else if (Mathf.Atan2(RandomDir.y, RandomDir.x) * Mathf.Rad2Deg > 90)
        {
            bul.transform.rotation = Quaternion.Euler(0, 180, -1 * (Mathf.Atan2(RandomDir.y, RandomDir.x) * Mathf.Rad2Deg + 180));
        }
        else if (Mathf.Atan2(RandomDir.y, RandomDir.x) * Mathf.Rad2Deg < -90)
        {
            bul.transform.rotation = Quaternion.Euler(0, 180, -1 * (Mathf.Atan2(RandomDir.y, RandomDir.x) * Mathf.Rad2Deg - 180));
        }
        cdTime = 0;
        StartCoroutine("waitFor5");

    }
    private float VelocityZ = 1 / 1.2f + 10 * 1.2f;
    private float VelocityY;
    private float VelocityX;
    private bool CannonSkill;
    public void CannonTrajectory()
    {
        if (!pressed)
        {
            TargetMp = Mp - MpCost;
            pressed = true;
        }
        TargetMp -= AimingCost;
        TargetMp = Mathf.Clamp(TargetMp, 0, MpMax);
        TrajectoryLine.enabled = true;
        TrajectoryLine.SetPosition(0, EmitPoint.transform.position);
        VelocityX = (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - EmitPoint.transform.position.x) / 1.2f;
        VelocityY = (Camera.main.ScreenToWorldPoint(Input.mousePosition).y - EmitPoint.transform.position.y) / 1.2f;
        VelocityZ = 1 / 1.2f + 10 * 1.2f;
        float i = 0.02f;
        while (i < 1 && (Mathf.Abs(EmitPoint.transform.position.x + VelocityX * i * 1.75f - Camera.main.ScreenToWorldPoint(Input.mousePosition).x) > 0.2f || i < 0.65f))
        {
            TrajectoryLine.positionCount = Mathf.RoundToInt(i / 0.02f) + 1;
            TrajectoryLine.SetPosition(Mathf.RoundToInt(i / 0.02f), new Vector3(EmitPoint.transform.position.x + VelocityX * i * 1.75f, EmitPoint.transform.position.y + (VelocityY * i + VelocityZ * i) * 1.95f, 0));
            VelocityZ -= 20 * 0.02f;
            i += 0.02f;
        }
        //for (float i = 0.02f; i < 1.5f; i += 0.02f)
        //{
        //    TrajectoryLine.positionCount = Mathf.RoundToInt(i / 0.02f) + 1;
        //    TrajectoryLine.SetPosition(Mathf.RoundToInt(i / 0.02f), new Vector3(EmitPoint.transform.position.x + VelocityX * i * 1.75f, EmitPoint.transform.position.y + (VelocityY * i + VelocityZ * i) * 1.95f));
        //    VelocityZ -= 20 * 0.02f;
        //}
    }
    public void CannonShoot()
    {
        AttackTimer = 0;
        pressed = false;
        CannonPressed = false;
        CannonAiming = false;
        TrajectoryLine.enabled = false;
        if (!CannonSkill)
        {
            var bul = Instantiate(Bullet, EmitPoint.transform.position, Quaternion.identity);
            bul.GetComponent<CannonBullet>().StartShoot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            bul.GetComponentInChildren<CannonExplosion>().damage = Mathf.RoundToInt(minDamage);
            bul.GetComponentInChildren<CannonExplosion>().ExpRange = expRange;
            if (BoostCannon)
            {
                bul.GetComponentInChildren<CircleCollider2D>().radius *= 1.5f;
            }
            minDamage = 10;
        }
        else
        {
            var bul1 = Instantiate(Bullet, EmitPoint.transform.position, Quaternion.identity);
            var bul2 = Instantiate(Bullet, EmitPoint.transform.position, Quaternion.identity);
            bul1.GetComponent<CannonBullet>().StartShoot(new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - 1, Camera.main.ScreenToWorldPoint(Input.mousePosition).y));
            bul2.GetComponent<CannonBullet>().StartShoot(new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + 1, Camera.main.ScreenToWorldPoint(Input.mousePosition).y));
            bul1.GetComponentInChildren<CannonExplosion>().damage = Mathf.RoundToInt(minDamage);
            bul2.GetComponentInChildren<CannonExplosion>().damage = Mathf.RoundToInt(minDamage);
            bul1.GetComponentInChildren<CannonExplosion>().ExpRange = expRange;
            bul2.GetComponentInChildren<CannonExplosion>().ExpRange = expRange;
            if (BoostCannon)
            {
                bul1.GetComponentInChildren<CircleCollider2D>().radius *= 1.5f;
                bul2.GetComponentInChildren<CircleCollider2D>().radius *= 1.5f;
            }
            minDamage = 10;
        }
        cdTime = 0;
        StartCoroutine("waitFor4");
    }
    void RotateGun()
    {
        dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (dir.x < 0)
        {
            //GunSprite.transform.rotation = Quaternion.Euler(180, 0, -angle);
            GunSprite.transform.rotation = Quaternion.Euler(180, 180, angle);

        }
        else
        {
            //GunSprite.transform.rotation = Quaternion.Euler(0, 0, angle);
            GunSprite.transform.rotation = Quaternion.Euler(0, 180, -angle);

        }
    }
    public GameObject gun1;
    public GameObject gun2;
    void RotateGun1()
    {
        dir = Input.mousePosition - Camera.main.WorldToScreenPoint(gun1.transform.position);
        dir2 = Input.mousePosition - Camera.main.WorldToScreenPoint(gun2.transform.position);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle2 = Mathf.Atan2(dir2.y, dir2.x) * Mathf.Rad2Deg;
        if (dir.x < 0)
        {
            //GunSprite.transform.rotation = Quaternion.Euler(180, 0, -angle);
            gun1.transform.rotation = Quaternion.Euler(180, 180, angle);
            gun2.transform.rotation = Quaternion.Euler(180, 180, angle2);
        }
        else
        {
            //GunSprite.transform.rotation = Quaternion.Euler(0, 0, angle);
            gun1.transform.rotation = Quaternion.Euler(0, 180, -angle);
            gun2.transform.rotation = Quaternion.Euler(0, 180, -angle2);
        }
    }
    void SniperUpdate()
    {
        //狙击射击（松开左键时）
        if ((isSniper && player.GetButtonUp("Fire")  && pressed) /*|| (Mp <= 5 && isSniper && pressed)*/)
        {
            main.GetComponent<PlayerMovement>().isAttacking = true;
            main.GetComponent<PlayerMovement>().HitBack();
            SniperShoot();
            if (!previousState.Equals("shoot"))
            {
                previousState = currentState;
            }
            SetCharacterState("shoot");
        }
        //狙击按下左键时瞄准
        if (isSniper && player.GetButton("Fire")/*|| player.GetAxis("MouseFire") > 0)*/ && Mp >= MpCost && CanAttack && cdTime > CdTime)
        {
            StartAiming = true;
        }
        if (StartAiming)
        {
            SniperAiming();
        }
        else
        {
            if (!currentState.Equals("shoot"))
            {
                SetCharacterState("idle");
            }
        }
        if (isSniper && player.GetButtonDown("Skill") && CanAttack && skillCd2 > SkillCd2)
        {
            Debug.Log("Sill");
            skillCd2 = 0;
            StartCoroutine("SkillBoost2");
        }
    }
    void CannonUpdate()
    {
        //Cannon按下左键蓄力
        if (isCannon && player.GetButton("Fire") && Mp >= MpCost && CanAttack && cdTime > CdTime)
        {
            CannonPressed = true;
            CannonAiming = true;
            if (!currentState.Equals("shoot"))
            {
                SetCharacterState("target");
                main.GetComponentInChildren<HeadControl>().isTarget = true;
            }
        }
        else
        {
            if (!currentState.Equals("shoot"))
            {
                SetCharacterState("idle");
            }
        }
        //Cannon松开左键发射
        if ((isCannon && player.GetButtonUp("Fire") && CannonPressed) /*|| (Mp <= 5 && isSniper && pressed)*/)
        {
            main.GetComponent<PlayerMovement>().isAttacking = true;
            CannonShoot();
            main.GetComponent<PlayerMovement>().HitBack();
            SetCharacterState("shoot");
            main.GetComponentInChildren<HeadControl>().isAttacking = true;
        }
        if (isCannon && player.GetButtonDown("Skill") && CanAttack && skillCd3 > SkillCd3)
        {
            skillCd3 = 0;
            StartCoroutine("SkillBoost3");
        }
    }
    private bool NormalShooting;
    void NormalUpdate()
    {
        //普通型射击（按下/按住左键）
        if (!isSniper && !isCannon && player.GetButton("Fire") && Mp >= MpCost && CanAttack && cdTime > CdTime)
        {
            main.GetComponent<PlayerMovement>().isAttacking = true;
            main.GetComponent<PlayerMovement>().HitBack();
            Shoot();
        }
        if (player.GetButtonUp("Fire") || Mp <= MpCost)
        {
            NormalShooting = false;
            main.GetComponent<PlayerMovement>().isAttacking = false;
        }
        if (NormalShooting)
        { 
            SetCharacterState("target");
        }
        else
        {
            SetCharacterState("idle");
        }
        if (!isSniper && !isCannon && player.GetButtonDown("Skill") && CanAttack && skillCd1 > SkillCd1)
        {
            skillCd1 = 0;
            StartCoroutine("SkillBoost1");
        }
    }
    void MpCalculate()
    {
        if (Mp < MpMax)
        {
            if (!MpBoost && !MpSlow)
                TargetMp += MpIncreaseSpeed * Time.deltaTime;
            else if (MpBoost)
            {
                TargetMp += MpIncreaseSpeed * MpBoostNum * Time.deltaTime;
            }
            else if (MpSlow)
            {
                TargetMp += MpIncreaseSpeed / MpSlowNum * Time.deltaTime;
            }
        }
        if (TargetMp < Mp)
        {
            Mp = Mathf.Lerp(Mp, TargetMp, Time.deltaTime * lerpSpeed);
        }
        else
        {
            Mp = Mathf.Lerp(Mp, TargetMp, Time.deltaTime * lerpSpeed);
        }
        slider.value = (float)(Mp / MpMax);

    }
    void Update()
    {
        skillCd1 += Time.deltaTime;
        skillCd2 += Time.deltaTime;
        skillCd3 += Time.deltaTime;
        cdTime += Time.deltaTime;
        AttackTimer += Time.deltaTime;
        SkillTimer += Time.deltaTime;
        if (AttackTimer > 3)
        {
            if (SkillTimer > 5)
            {
                moveNum = 6;
            }
            else
            {
                moveNum = 1;
            }
        }
        else 
        {
            if (SkillTimer > 5)
            {
                moveNum = 5;
            }
            else
            {
                moveNum = 0;
            }
        }
        if (dead)
        {
            SetCharacterState("die");
        }
        else
        {if (isSniper || isCannon)
            {
                RotateGun();
            }
            else 
            {
                RotateGun1();
            }
            if (isSniper)
                SniperUpdate();
            if (!isSniper && !isCannon)
                NormalUpdate();
            if (isCannon)
                CannonUpdate();
        }
        MpCalculate();
    }
    private void FixedUpdate()
    {
        if (CannonAiming)
        {
            minDamage += Time.fixedDeltaTime;
            minDamage = Mathf.Clamp(minDamage, 10, maxDamage);
            CannonTrajectory();
        }
    }
}