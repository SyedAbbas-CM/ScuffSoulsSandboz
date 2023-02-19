using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator anim;
    public int stuff;



    void Start()
    {
        anim = GetComponent<Animator>();    
    }
    public void Walk(bool walk)
    {
        anim.SetBool(AnimationTags.WALK_PARAMETER, walk);
    }
    public void Run(bool run)
    {
        anim.SetBool(AnimationTags.RUN_PARAMETER, run);
    }
    public void Attack()
    {
        anim.SetTrigger(AnimationTags.ATTACK_PARAMETER);
    }
    public void dead()
    {
        anim.SetTrigger(AnimationTags.DEAD_PARAMETER);
    }
    void Update()
    {
        
    }
}
