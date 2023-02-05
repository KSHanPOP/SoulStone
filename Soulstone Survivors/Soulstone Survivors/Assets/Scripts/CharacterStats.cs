using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHp;
    public int damage;
    public int armor;
    
    public int hp;

    private void Awake()
    {
        hp = maxHp;
    }

}
