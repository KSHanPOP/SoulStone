using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ObjectpoolManager objectPool; 
    public SkillPool skillPool;
    public GameObject player;

    private void Awake()
    {
        Instance = this;
    }
}
