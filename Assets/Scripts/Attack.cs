using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Attack : MonoBehaviour
{
    public GameObject gun;
    public GameObject EmitPos;
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
    }
    public void Shoot()
    {
        Instantiate(Bullet, EmitPos.transform.position, Quaternion.identity);
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
        if (Input.GetKey(KeyCode.Mouse0) && cdTime > CdTime && Mp >= MpCost && CanAttack)  
        {
            anim.SetTrigger("Attack");
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
