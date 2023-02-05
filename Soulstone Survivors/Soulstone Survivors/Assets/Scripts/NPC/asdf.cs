using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvantRelay : MonoBehaviour
{
    public GameObject gameObject;

    private bool idle = true;
    void WolfAttackFinish()
    {
        idle = true;
    }
}
