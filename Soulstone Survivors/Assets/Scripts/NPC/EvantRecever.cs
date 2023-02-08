using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvantRecever : MonoBehaviour
{
    private Animator animator;
    public GameObject parentObject;
    public NPCController parentScript;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        parentScript = parentObject.GetComponent<NPCController>();

    }
    void WolfAttackFinish()
    {
        animator.SetBool("AttackIdle", true);
    }

    private void Hit()
    {
        parentScript.Hit();
    }
}
