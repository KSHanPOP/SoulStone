using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    private float timer;
    public float spawnDelayTime;
    private Vector3 RandomSpawnPoint;
    private int spawnMaxCount;
    private void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        spawnMaxCount = GameManager.Instance.maxEnemyCount;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnDelayTime && GameManager.Instance.enemyCount < spawnMaxCount)
        {
            timer = 0;

            Spawn();
            GameManager.Instance.enemyCount++;
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


[System.Serializable]
public class SpawnData
{
    public int enemyType;
    public float spawnTime;
    public int health;
    public float speed;
}