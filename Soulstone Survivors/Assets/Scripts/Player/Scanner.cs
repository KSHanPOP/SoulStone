using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    Collider[] colliders;
    public RaycastHit[] targets;
    public Transform nearestTarget;
    private void FixedUpdate()
    {
        colliders = Physics.OverlapSphere(transform.position, scanRange, targetLayer);
        nearestTarget = GetNearest();
        //Physics.RaycastAll(transform.position, range, targetLayer);
        //Physics.Raycast(transform.position, transform.forward, out targets, range, targetLayer);
    }

    Transform GetNearest()
    {
        Transform result = null;
        float diff = 10000f;

        Vector3 myPos = transform.position;
        foreach (var collider in colliders)
        {
            Vector3 targetPos = collider.transform.position;
            float curDiff = Vector3.Distance(myPos, targetPos);

            if (curDiff < diff)
            {
                diff = curDiff;
                result = collider.transform;
            }
        }

        return result;
    }
}
