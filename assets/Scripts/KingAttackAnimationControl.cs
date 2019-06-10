using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingAttackAnimationControl : MonoBehaviour {

    private static KingAttackAnimationControl _instance;
    public static KingAttackAnimationControl instance
    {
        get
        {
            return _instance;
        }
    }

    public Animator animator;

    public bool isAttack;

    private void Update()
    {
        if (isAttack)
        {
            animator.SetBool("isAttack", true);
        }
        else
        {
            animator.SetBool("isAttack", false);
        }
    }

    public void PlayAttackAnimMT()
    {
        isAttack = true;
    }

    public void StopAttackAnimMT()
    {
        isAttack = false;
    }
}
