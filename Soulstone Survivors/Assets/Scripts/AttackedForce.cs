using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackedForce : MonoBehaviour, IAttackable
{
    public float up = 1f;
    public float power = 5f;
    private Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    public void OnAttack(GameObject attacker, Attack attack)
    {
        var dir = transform.position - attacker.transform.position;
        dir.y += up;
        dir.Normalize();
        rigid.AddForce(dir * power, ForceMode.Impulse);
        //Debug.Log("hit");
        //rigid.MovePosition(dir*2);
        //rigid.velocity = dir * power;
    }

    public void OnAttack(Transform attacker)
    {
        var dir = transform.position - attacker.transform.position;
        dir.y += up;
        dir.Normalize();
        rigid.AddForce(dir * power, ForceMode.Impulse);
    }

    private void Update()
    {

    }
}
