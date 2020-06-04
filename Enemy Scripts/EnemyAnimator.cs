using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour {

    private Animator anim;

    //gets animator component from anim
	void Awake () 
    {
        anim = GetComponent<Animator>();	
	}
	
    //Used for animation: Allows enemy to activate walk animation
    public void Walk(bool walk) 
    {
        anim.SetBool(AnimationTags.WALK_PARAMETER, walk);
    }

    //Used for animation: Allows enemy to activate run animation
    public void Run(bool run) 
    {
        anim.SetBool(AnimationTags.RUN_PARAMETER, run);
    }

    //Used for animation: Allows enemy to activate attack animation
    public void Attack() 
    {
        anim.SetTrigger(AnimationTags.ATTACK_TRIGGER);
    }


    //Used for animation: Allows enemy to activate death animation
    public void Dead() 
    {
        anim.SetTrigger(AnimationTags.DEAD_TRIGGER);
    }

} // class































