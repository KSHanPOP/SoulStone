using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Spell.asset", menuName = "Attack/Spell")]
public class Spell : AttackDefinition
{
    public Projectile prefab;
    public float speed = 10f;
    public float distance = 20f;
    public void Cast(GameObject attacker, Vector3 position, Vector3 targetPos, int layer)
    {
        var projectile = Instantiate(prefab, position, Quaternion.identity);
        projectile.Fire(attacker, targetPos, speed, distance);
        projectile.OnCollided += OnCollided;
        projectile.gameObject.layer = layer;
    }
    public void OnCollided(GameObject attacker, GameObject defender)
    {
        if (attacker == null || defender == null)
            return;

        var aStats = attacker.GetComponent<CharacterStats>();
        var dStats = defender.GetComponent<CharacterStats>();
        var attack = CreatAttack(aStats, dStats);
        var attackables = defender.GetComponentsInChildren<IAttackable>();

        foreach (var attackable in attackables)
        {
            attackable.OnAttack(attacker, attack);
        }
    }
}

