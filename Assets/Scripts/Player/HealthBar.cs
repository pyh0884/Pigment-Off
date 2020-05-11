using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float Hp = 100;
    public float HpMax = 100;
    public int IncreaseHp;
    public GameManager gm;
    public bool cheat;
    public bool Shield;
    public float TargetHp = 100;
    public float lerpSpeed = 5;
    public float lerpSpeed2 = 5;
    public int playerNum = 0;
    bool dead = false;
    public AudioSource dieAudio;
    void Start()
    {
        Hp = HpMax;
        TargetHp = HpMax;
        gm = FindObjectOfType<GameManager>();
        //Hp = gm.HP;
        //HpMax = gm.MAXHP;
        currentHealth();
        gameObject.transform.parent.gameObject.GetComponentInChildren<Canvas>().worldCamera = FindObjectOfType<Camera>();
    }

    public void Damage(float damageCount)
    {
        //伤害特效 
        //       FindObjectOfType<AudioManager>().Play("Player_Hit");
        if (damageCount < 0)
        {
            TargetHp -= damageCount;
            TargetHp = Mathf.Clamp(TargetHp, 0, HpMax);
            //currentHealth();

        }//回血特效 
        if (damageCount > 0)
        {
            if (!cheat)
            {
                GetComponent<AudioSource>().Play();
                if (!Shield)
                {
                    TargetHp -= damageCount;
                }
                else
                {
                    Shield = false;
                    FindObjectOfType<TopCanvas>().ShieldOff(playerNum);
                }
            }
            TargetHp = Mathf.Clamp(TargetHp, 0, HpMax);
            //currentHealth();
        }
    }
    public void ShieldUp()
    {
        FindObjectOfType<TopCanvas>().Shield(playerNum);
        Shield = true;
    }
    public void IncreaseMax()
    {
        HpMax += IncreaseHp;
        TargetHp += IncreaseHp + 20;
    }

    void currentHealth()
    {
        if ((TargetHp <= 0 || Hp <= 0)&& !dead)
        {
            dead = true;
            StartCoroutine("Die");
        }
        if (TargetHp < Hp)
        {
            Hp = Mathf.Lerp(Hp, TargetHp, Time.deltaTime * lerpSpeed);
        }
        else
        {
            Hp = Mathf.Lerp(Hp, TargetHp, Time.deltaTime * lerpSpeed2);
        }
        slider.value = (float)(Hp / HpMax);
    }
    public void die() 
    {
        StartCoroutine("Die");
    }
    IEnumerator Die()
    {
        Debug.Log(gameObject.name + "Die");
        dieAudio.Play();
        GetComponent<PlayerMovement>().controllable = false;
        GetComponent<PlayerMovement>().dead = true;
        GetComponentInChildren<Attack>().dead = true;
        GetComponentInChildren<Attack>().CanAttack = false;
        GetComponentInChildren<HeadControl>().dead = true;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        Time.timeScale = 1;
        gm.Respawn(playerNum);
        yield return new WaitForSeconds(1);
        Destroy(gameObject.transform.parent.gameObject);
    }
    private void Update()
    {
        playerNum = GetComponent<PlayerMovement>().playerID + 1;
        //HpMax = gm.MAXHP;
        currentHealth();
        //if (Input.GetKeyDown(KeyCode.F11)) 
        //{
        //    StartCoroutine("Die");
        //}
    }
}
