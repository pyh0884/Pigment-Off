using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Attack : MonoBehaviour
{
    //Sniper
    [Header("狙击角色：")]
    public bool isSniper;
    public LayerMask BlockRay;
    public LineRenderer laserLeft;
    public LineRenderer laserRight;
    private RaycastHit2D hit;
    private bool pressed = false;
    private Vector3 EndPoint;
    private Vector3 LeftPoint;
    private Vector3 RightPoint;
    //--------------------------------
    //Cannon
    [Header("重炮角色：")]
    public bool isCannon;
    public LayerMask CannonBlockRay;
    //--------------------------------
    //Basic Attack Parameters
    [Header("基本参数：")]
    private Vector3 dir;
    public GameObject GunSprite;
    public GameObject EmitPoint;
    public GameObject Bullet;
    [Header("攻击间隔")]
    public float CdTime;
    private float cdTime = 10;
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
        anim = main.GetComponent<Animator>();
        if (isSniper)
        {
            laserLeft.enabled = true;
            laserRight.enabled = true;
        }
    }
    public void Shoot()
    {
        var bul=Instantiate(Bullet, EmitPoint.transform.position, Quaternion.identity);
        bul.GetComponent<BulletAI>().SetInitial(dir);
        cdTime = 0;
        TargetMp = Mp - MpCost;
        TargetMp = Mathf.Clamp(TargetMp, 0, MpMax);
    }

    public void SniperAiming()
    {
        laserLeft.SetPosition(0, EmitPoint.transform.position);
        laserRight.SetPosition(0, EmitPoint.transform.position);
        EndPoint = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - EmitPoint.transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - EmitPoint.transform.position.y, 0);
        if (!pressed)
        {
            LeftPoint = new Vector3(-1 * EndPoint.y, EndPoint.x, 0);
            RightPoint = new Vector3(EndPoint.y, -1 * EndPoint.x, 0);
            pressed = true;
            laserLeft.enabled = true;
            laserRight.enabled = true;
        }
        hit = Physics2D.Raycast(EmitPoint.transform.position, EndPoint, Mathf.Infinity, BlockRay);
        if (hit)
        {
            // laser.SetPosition(1, hit.point);
            laserLeft.SetPosition(1, hit.point);
            laserRight.SetPosition(1, hit.point);
        }
        else
        {
            // laser.SetPosition(1, EmitPoint.transform.position + EndPoint.normalized * 50);
            laserLeft.SetPosition(1, EmitPoint.transform.position + EndPoint.normalized * 50);
            laserRight.SetPosition(1, EmitPoint.transform.position + EndPoint.normalized * 50);
        }
    }
    void Update()
    {
        cdTime += Time.deltaTime;
        dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        GunSprite.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //Sniper
        if (isSniper && Input.GetKey(KeyCode.Mouse0) && Mp >= MpCost && CanAttack && cdTime > CdTime)
        {
            SniperAiming();
        }
        //--------------------------------------------------------
        else if (Input.GetKey(KeyCode.Mouse0) && Mp >= MpCost && CanAttack && cdTime > CdTime) 
        {
            anim.SetTrigger("Attack");
        }
        //狙击射击（松开左键时）
        if (isSniper && Input.GetKeyUp(KeyCode.Mouse0))
        {
            pressed = false;
            anim.SetTrigger("Attack"); //不同的Animatioin,动画事件使用新Method
            //var bul = Instantiate(Bullet, EmitPoint.transform.position, Quaternion.identity);
            //bul.GetComponent<BulletAI>().SetInitial(dir);
            laserLeft.enabled = false;
            laserRight.enabled = false;
            cdTime = 0;
            TargetMp = Mp - MpCost;
            TargetMp = Mathf.Clamp(TargetMp, 0, MpMax);
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

}
