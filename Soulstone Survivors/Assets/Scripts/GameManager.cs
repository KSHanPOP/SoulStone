using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ObjectpoolManager objectPool; 
    public SkillPool skillPool;
    public GameObject player;

    public int maxEnemyCount;
    public int enemyCount;
    private void Awake()
    {
        Instance = this;
    }
}
