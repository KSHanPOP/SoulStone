using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneMissiles : MonoBehaviour
{
    public float damage;
    public int per;
    public int rotationSpeed = 150;

    private Transform player;
    public void Init(float damage, int per)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        this.damage = damage;
        this.per = per;
        rotationSpeed = 150;
    }

    private void FixedUpdate()
    {
        //Vector3 rotationVector = new Vector3(0, 1, 0);

        //Transform parentTransform = player.transform;
        //Vector3 parentPosition = parentTransform.position;
        ////rotationSpeed = 150;
        //Debug.Log(rotationSpeed);
        //transform.RotateAround(parentPosition, Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider collider)
    {
        //if (!collider.CompareTag("Enemy") || per == -1)
        //{
        //    return;
        //}

        //per--;

        //if (per == -1)
        //{
        //    rb.velocity = Vector3.zero;
        //    gameObject.SetActive(false);
        //}

    }
}
    //Quaternion localRotation = Quaternion.Euler(0f, Time.time * rotationSpeed, 0f);
    //Vector3 worldPos = player.position + (localRotation * (transform.position - player.position));
    //transform.position = worldPos;

    //transform.LookAt(player);
    //uaternion relativeRotation = Quaternion.Inverse(transform.root.rotation) * transform.rotation;
    //transform.localRotation = Quaternion.identity * relativeRotation;
    //transform.localRotation = Quaternion.identity ;
    //transform.rotation = Quaternion.Euler(0f, 45f, 0f);
    // transform.RotateAround(transform.position, Vector3.up, 150 * Time.deltaTime);

