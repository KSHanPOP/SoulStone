using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoint;
    private float timer;
    private Vector3 RandomSpawnPoint;
    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1.2f)
        {
            timer = 0;
            Spawn();
        }

        //if (Input.GetKeyUp(KeyCode.F))
        //{
        //}
    }

    private void Spawn()
    {


        // GetRandomPoint()

        // enemy.transform.position;
        for (int i = 0; i < 30; ++i)
        {
            if (GetRandomPoint(spawnPoint[Random.Range(1, spawnPoint.Length)].position, 1f, out RandomSpawnPoint) && RandomSpawnPoint != Vector3.zero)
            {
                GameObject enemy = GameManager.Instance.objectPool.Get(0);

                enemy.transform.position = RandomSpawnPoint;
                return;
            }
        }
        //spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }

    bool GetRandomPoint(Vector3 center, float range, out Vector3 result)
    {
        //for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}
