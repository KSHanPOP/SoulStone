using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructedEvent : MonoBehaviour, IDestructible
{
    public System.Action OnDie;

    public void OnDestruction(GameObject attacker)
    {
        if (OnDie != null)
        {
            OnDie();
        }
    }
}
