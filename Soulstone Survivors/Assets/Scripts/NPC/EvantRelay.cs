using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvantRecever : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void WolfAttackFinish()
    {
        animator.SetBool("AttackIdle", true);
    }
}
