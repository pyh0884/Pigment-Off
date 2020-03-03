using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Flag : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle, attack;
    private string currentAnimation;
    private string currentName;
    public float hp;
    public float MaxHp;
    private bool dead = false;
    GameManager gm;
    public GameObject exp;
    public GameObject flag;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        MaxHp = Mathf.Clamp(gm.PlayTime * 5 / 9, 1, 100);
        hp = MaxHp;
        currentAnimation = "idle";
        SetCharacterState(currentAnimation);
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
    public void SetCharacterState(string state)
    {
        if (state.Equals("attack"))
        {
            SetAnimation(attack, false, 1f);
        }
        else if (state.Equals("idle"))
        {
            SetAnimation(idle, true, 1f);
        }
    }
    IEnumerator WaitForHit() 
    {
        SetCharacterState("attack");
        yield return new WaitForSeconds(0.66f);
        SetCharacterState("idle");
    }
    public void Damage(float damageCount)
    {
        //伤害特效 
        //       FindObjectOfType<AudioManager>().Play("Player_Hit");
        if (damageCount > 0)
        {
            hp -= damageCount;
            hp = Mathf.Clamp(hp, 0, MaxHp);
            StartCoroutine("WaitForHit");
        }
    }
    IEnumerator desSelf() 
    {
        yield return new WaitForSeconds(0.66f);
        flag.SetActive(true);
        flag.transform.parent = null;
        Destroy(gameObject);
    }
    void Update()
    {
        if ((hp <= 0) && !dead)
        {
            dead = true;
            //StartCoroutine("Die");
            GetComponent<MeshRenderer>().enabled = false;
            exp.SetActive(true);
            StartCoroutine("desSelf");
        }

    }
}
