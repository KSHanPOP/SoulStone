using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulStone : MonoBehaviour
{
    public int exp;
    public float speed = 10f;
    public float rotateSpeed = 5f;
    public float explosionRadius = 1f;
    public float explosionForce = 500f;
    public float distance;
    private Transform target;


    private void Start()
    {
        target = FindClosestTarget();
    }

    private void Update()
    {
        if (target == null)
        {
            // Ÿ���� ������ �̵��� �մϴ�.
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if(Vector3.Distance(transform.position, target.position) <= distance)
        {
            // Ÿ���� ������ Ÿ�� �������� ȸ���ϰ� �̵��մϴ�.
            Vector3 direction = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            // Ÿ�ٰ��� �Ÿ��� ���� �����̸� �������.
            if (Vector3.Distance(transform.position, target.position) < explosionRadius)
            {
                Explode();
            }
        }
    }

    private Transform FindClosestTarget()
    {
        // Ÿ���� ã�Ƽ� ��ȯ
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        GameObject closestPlayer = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject gameObject in player)
        {
            float distance = Vector3.Distance(transform.position, gameObject.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayer = gameObject;
            }
        }
        if (closestPlayer != null)
        {
            return closestPlayer.transform;
        }
        else
        {
            return null;
        }
    }

    private void Explode()
    {

        gameObject.SetActive(false);
    }
}
