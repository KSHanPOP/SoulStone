using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoSkill : MonoBehaviour
{
    public int id;
    public int prifabId;
    public float damage;
    public int count;
    public float speed;

    private float timer;

    PlayerMovement player;

    private Transform parentTransform;
    private Vector3 localRotation;
    private void Start()
    {
        Init();
    }
    private void Awake()
    {
        player = GetComponentInParent<PlayerMovement>();
    }
    private void Update()
    {
        switch (id)
        {
            case 0:
                //transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
                transform.Rotate(Vector3.up * speed * Time.deltaTime);
                break;
            default:
                timer += Time.deltaTime;
                if (timer > speed)
                {
                    timer = 0f;
                    Fire();
                }
                break;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            LevelUp(20, 5);
        }
        //Debug.Log(speed);
    }
    public void LevelUp(float damege, int count)
    {
        this.damage = damege;
        this.count += count;
        if (id == 0)
        {
            Batch();
        }
        
    }
    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = 150;
                Batch();
                break;
            default:
                speed = 1f;
                break;
        }
    }
    private void Batch()
    {
        for (int index = 0; index < count; index++)
        {
            Transform bullet;
            if (index < transform.childCount)
            {
                bullet = transform.GetChild(index);
            }
            else
            {
                bullet = GameManager.Instance.skillPool.Get(prifabId).transform;
                bullet.parent = transform;
            }

            Vector3 position = transform.position + Quaternion.Euler(0, (360.0f / count) * index, 0) * (Vector3.forward * 5);
            bullet.position = position;
            bullet.localRotation = Quaternion.identity;

            bullet.GetComponent<ArcaneMissiles>().Init(damage, -1);
        }

        //for (int index = 0; index < count; index++)
        //{
        //    Transform bullet;
        //    if (index < transform.childCount)
        //    {
        //        bullet = transform.GetChild(index);
        //    }
        //    else
        //    {
        //        bullet = GameManager.Instance.skillPool.Get(prifabId).transform;
        //        bullet.parent = transform;
        //    }

        //    bullet.localPosition= Vector3.zero;
        //    bullet.localRotation= Quaternion.identity;


        //    Debug.Log(transform.childCount);

        //    Vector3 rotVec = Vector3.forward * 360 * index / count;
        //    bullet.Rotate(rotVec);
        //    bullet.Translate(bullet.up * 1.5f, Space.World);
        //    bullet.GetComponent<ArcaneMissiles>().Init(damage, -1);
        //}
    }
    private void Fire()
    {
        if (!player.scanner.nearestTarget)
        {
            return;
        }

        Vector3 targetPos = player.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;

        Transform bullet = GameManager.Instance.skillPool.Get(prifabId).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        bullet.GetComponent<FireboltSkill>().Init(damage, count, dir);
    }
}
