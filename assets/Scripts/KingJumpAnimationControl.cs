using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingJumpAnimationControl : MonoBehaviour {

    private static KingJumpAnimationControl _instance;
    public static KingJumpAnimationControl instance
    {
        get
        {
            return _instance;
        }
    }

    public Animator animator;

    public bool isJump = false;

    private void Update()
    {
        if (isJump)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }


    }

    public void PlayJumpAnimMT()
    {
        isJump = true;
    }

    public void StopJumpAnimMT()
    {
        isJump = false; 
    }
}
