using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void Init(float damage, int per, Vector3 dir)
    {
        this.damage = damage;
        this.per = per;

        if (per > -1)
        {
            rb.velocity = dir * 15f;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Enemy") || per == -1)
        {
            return;
        }

        per--;

        if (per == -1)
        {
            rb.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }

    }
}
