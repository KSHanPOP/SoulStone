using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1.捞悼
// 2.面倒 贸府
// 3.昏力

public class Projectile : MonoBehaviour
{
    public event System.Action<GameObject, GameObject> OnCollided;

    private GameObject attacker;
    private Vector3 target;
    private float speed;
    private float distance;

    private Vector3 startPos;
    private Vector3 velocity;

    public GameObject particlePrefab;
    public void Fire(GameObject attacker, Vector3 targetPos, float speed, float distance)
    {
        this.attacker = attacker;
        this.target = targetPos;
        this.speed = speed;
        this.distance = distance;

        startPos = transform.position;
        transform.LookAt(targetPos);

        velocity = transform.forward * speed;
    }
    private void Update()
    {
        transform.Translate(velocity * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, startPos) > distance)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (OnCollided != null)
        {
            OnCollided(attacker, other.gameObject);
            var newGo = Instantiate(particlePrefab, transform.position, Quaternion.identity);
            Destroy(newGo, 2f);
        }
        Destroy(gameObject);
    }
}
