using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sniper : MonoBehaviour
{
    public GameObject EmitPoint;
    private LineRenderer laser;
    private RaycastHit2D hit;
    public LayerMask BlockRay;
    private Vector3 EndPoint;

    public GameObject gun;
    public GameObject Bullet;
    public float CdTime;
    private float cdTime = 10;
    public Vector3 rotation;
    public Slider slider;
    public float Mp = 100;
    public float MpMax = 100;
    public float TargetMp = 100;
    public float lerpSpeed = 5;
    public float MpIncreaseSpeed = 5;
    public bool MpBoost = false;
    public bool MpSlow = false;
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
        laser = GetComponent<LineRenderer>();
        laser.enabled = true;
    }
    public void Shoot()
    {
        Instantiate(Bullet, EmitPoint.transform.position, Quaternion.identity);
        cdTime = 0;
        TargetMp = Mp - MpCost;
        TargetMp = Mathf.Clamp(TargetMp, 0, MpMax);
    }
    void Update()
    {
        cdTime += Time.deltaTime;
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        laser.SetPosition(0, EmitPoint.transform.position);
        EndPoint = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - EmitPoint.transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y - EmitPoint.transform.position.y, 0);
        hit = Physics2D.Raycast(EmitPoint.transform.position, EndPoint, Mathf.Infinity, BlockRay);
        if (hit)
            laser.SetPosition(1, hit.point);
        else
        {
            laser.SetPosition(1, EmitPoint.transform.position + EndPoint.normalized * 50);
        }
        if (cdTime > CdTime)
        {
            laser.enabled = true;
            if (Input.GetKey(KeyCode.Mouse0) && Mp >= MpCost && CanAttack)
            {
                anim.SetTrigger("Attack");
            }
        }
        else
        {
            laser.enabled = false;
        }
        if (Mp < MpMax)
        {
            if (!MpBoost && !MpSlow)
                TargetMp += MpIncreaseSpeed * Time.deltaTime;
            else if (MpBoost)
            {
                TargetMp += MpIncreaseSpeed * 2 * Time.deltaTime;

            }
            else if (MpSlow)
            {
                TargetMp += MpIncreaseSpeed / 2 * Time.deltaTime;
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
