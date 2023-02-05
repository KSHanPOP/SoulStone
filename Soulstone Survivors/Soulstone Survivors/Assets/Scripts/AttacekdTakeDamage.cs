using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttacekdTakeDamage : MonoBehaviour, IAttackable
{
    private CharacterStats stats;
    private void Awake()
    {
        stats = GetComponent<CharacterStats>();
    }
    public void OnAttack(GameObject attacker, Attack attack)
    {
        if (stats == null)
            return;

        stats.hp -= attack.Damage;
        if (stats.hp <= 0)
        {
            stats.hp = 0;

            var destructbiles = GetComponentsInChildren<IDestructible>();
            foreach (var destructible in destructbiles)
            {
                destructible.OnDestruction(attacker);
            }
        }
    }

}
