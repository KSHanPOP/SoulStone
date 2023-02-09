using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSkill : MonoBehaviour
{
    public int id;
    public int prifabId;
    public float damage;
    public int count;
    public float speed;

    private void Update()
    {

    }
    public void Init()
    {
        switch (id)
        {
            case 0:
                Batch();
                break;
            default: break;
        }
    }
    private void Batch()
    {
        for (int index = 0; index < count; index++)
        {
            var skill = GameManager.Instance.skillPool.Get(prifabId).transform;
        }
    }

    //public int skillId;
    //GameObject[] Skills;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    for (int i = 0; i < 6; ++i)
    //    {
    //        Skills[i] = GameManager.Instance.skillPool.Get(i);
    //        if (Skills[i] == null)
    //            return;

    //        Skills[i]
    //    }

    //}
}
