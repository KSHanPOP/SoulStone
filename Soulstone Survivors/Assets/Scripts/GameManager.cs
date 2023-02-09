using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ObjectpoolManager objectPool; 
    private void Awake()
    {
        Instance = this;
    }
}
