using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Attack : MonoBehaviour
{
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
    //--------------------------------
    //Cannon
    [Header("重炮角色：")]
    public bool isCannon;
    public LineRenderer TrajectoryLine;
    private bool CannonAiming = false;
    private bool CannonPressed = false;
    //--------------------------------
    //Basic Attack Parameters
    [Header("基本参数：")]
    private Vector3 dir;
    private float angle;
    public GameObject GunSprite;
    public GameObject EmitPoint;
    public GameObject Bullet;
    [Header("攻击间隔")]
    public float CdTime;
    private float cdTime = 10;
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
    private Animator anim;
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
    void Start()
    {
        cdTime = 10;
        tempCD = CdTime;
        anim = main.GetComponent<Animator>();
    }
    public void Shoot() //普通型攻击
    {
        var bul = Instantiate(Bullet, EmitPoint.transform.position, Quaternion.identity);
        if (Mathf.Sqrt(Mathf.Pow(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x, 2) + Mathf.Pow(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, 2)) < 12) //Todo：增加射程变量
        {
            //Debug.Log(Mathf.Sqrt(Mathf.Pow(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x, 2) + Mathf.Pow(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, 2)));
            bul.GetComponent<BulletAI>().Range = Mathf.Sqrt(Mathf.Pow(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x, 2) + Mathf.Pow(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y, 2));
        }
        bul.GetComponent<Rigidbody2D>().velocity = new Vector2(dir.x, dir.y).normalized * bul.GetComponent<BulletAI>().ShootSpeed;
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
        //bul.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, Vector3.forward);

        cdTime = 0;
        TargetMp = Mp - MpCost;
        TargetMp = Mathf.Clamp(TargetMp, 0, MpMax);
    }

    public void SniperAiming()
    {
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
        StartAiming = false;
        laserLeft.enabled = false;
        laserRight.enabled = false;
        pressed = false;
        anim.SetTrigger("Attack"); //不同的Animatioin,动画事件使用新Method
        RandomDir = (EmitPoint.transform.position + LeftPoint + (RightPoint - LeftPoint).normalized * Random.Range(0, (RightPoint - LeftPoint).magnitude)) - EmitPoint.transform.position;
        var bul = Instantiate(Bullet, EmitPoint.transform.position, Quaternion.identity);
        bul.GetComponent<Rigidbody2D>().velocity = new Vector2(RandomDir.x, RandomDir.y).normalized * bul.GetComponent<BulletAI>().ShootSpeed;
        bul.transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(RandomDir.y, RandomDir.x) * Mathf.Rad2Deg, Vector3.forward);
        cdTime = 0;
    }
    private float VelocityZ = 1 / 1.2f + 10 * 1.2f;
    private float VelocityY;
    private float VelocityX;
    public void CannonTrajectory()
    {
        TrajectoryLine.enabled = true;
        TrajectoryLine.SetPosition(0, EmitPoint.transform.position);
        VelocityX = (Camera.main.ScreenToWorldPoint(Input.mousePosition).x - EmitPoint.transform.position.x) / 1.2f;
        VelocityY = (Camera.main.ScreenToWorldPoint(Input.mousePosition).y - EmitPoint.transform.position.y) / 1.2f;
        VelocityZ = 1 / 1.2f + 10 * 1.2f;
        float i = 0.02f;
        while (i < 1 && (Mathf.Abs(EmitPoint.transform.position.x + VelocityX * i * 1.75f - Camera.main.ScreenToWorldPoint(Input.mousePosition).x) > 0.2f || i < 0.65f)) 
        {
            TrajectoryLine.positionCount = Mathf.RoundToInt(i / 0.02f) + 1;
            TrajectoryLine.SetPosition(Mathf.RoundToInt(i / 0.02f), new Vector3(EmitPoint.transform.position.x + VelocityX * i*1.75f, EmitPoint.transform.position.y + (VelocityY * i + VelocityZ * i) * 1.95f,0));
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
        CannonAiming = false;
        TrajectoryLine.enabled = false;
        var bul = Instantiate(Bullet, EmitPoint.transform.position, Quaternion.identity);
        bul.GetComponent<CannonBullet>().StartShoot(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
    void Update()
    {
        cdTime += Time.deltaTime;
        dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        GunSprite.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //狙击射击（松开左键时）
        if ((isSniper && Input.GetKeyUp(KeyCode.Mouse0) && pressed) /*|| (Mp <= 5 && isSniper && pressed)*/)
        {
            SniperShoot();
        }
        //狙击按下左键时瞄准
        if (isSniper && Input.GetKey(KeyCode.Mouse0) && Mp >= MpCost && CanAttack && cdTime > CdTime)
        {
            StartAiming = true;
        }
        if (StartAiming)
        {
            SniperAiming();
        }
        //Cannon按下左键蓄力？？？？？？
        if (isCannon && Input.GetKey(KeyCode.Mouse0) && Mp >= MpCost && CanAttack && cdTime > CdTime)
        {
            CannonPressed = true;
            CannonAiming = true;
        }

        //Cannon松开左键发射
        if ((isCannon && Input.GetKeyUp(KeyCode.Mouse0) && CannonPressed) /*|| (Mp <= 5 && isSniper && pressed)*/)
        {
            CannonShoot();
        }
        //普通型射击（按下/按住左键）
        if (!isSniper && Input.GetKey(KeyCode.Mouse0) && Mp >= MpCost && CanAttack && cdTime > CdTime)
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
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
    private void FixedUpdate()
    {
        if (CannonAiming)
        {
            CannonTrajectory();
        }
    }

}
