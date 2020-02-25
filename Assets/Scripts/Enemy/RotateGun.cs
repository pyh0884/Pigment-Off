using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class RotateGun : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset idle, attack, target;
    private string currentState;
    public string currentAnimation;
    public string previousState;
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

    public void SetCharacterState(string state)
    {
        if (state.Equals("target"))
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
        currentState = state;
    }

}
