using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireboltSkill : MonoBehaviour
{
    public float damage;
    public int per;
    private float range;
    public float maxRange = 0.5f;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Init(float damage, int per, Vector3 dir)
    {
        range = maxRange;
        this.damage = damage;
        this.per = per;
        if (per > -1)
        {
            rb.velocity = dir.normalized * 30f;
        }
    }


    private void Update()
    {
        range -= Time.deltaTime;

        if (range < 0f)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        //if (!collider.CompareTag("Enemy") || per == -1)
        //{
        //    return;
        //}

        //per--;

        //if (per == -1)
        //{
        //    rb.velocity = Vector3.zero;
        //    gameObject.SetActive(false);
        //}

    }
}
