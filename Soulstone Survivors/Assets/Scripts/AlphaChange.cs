using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaChange : MonoBehaviour
{
    public Material hitMaterial;
    private Material defaultMaterial;

    void Start()
    {
        defaultMaterial = GetComponentInChildren<Renderer>().material;
    }

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Renderer renderer = GetComponentInChildren<Renderer>();
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                // if (materials[i].name == hitMaterial.name)
                {
                    materials[i].color = Color.red;
                    break;
                }
            }

            //// 0.5초 후에 원래 Material로 변경합니다.
            Invoke("RestoreMaterial", 0.3f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    Renderer renderer = GetComponentInChildren<Renderer>();
        //    Material[] materials = renderer.materials;
        //    for (int i = 0; i < materials.Length; i++)
        //    {
        //        // if (materials[i].name == hitMaterial.name)
        //        {
        //            materials[i].color = Color.red;
        //            break;
        //        }
        //    }

        //    //// 0.5초 후에 원래 Material로 변경합니다.
        //    Invoke("RestoreMaterial", 0.5f);
        //}
    }

    private void RestoreMaterial()
    {
        Renderer renderer = GetComponentInChildren<Renderer>();
        Material[] materials = renderer.materials;
        for (int i = 0; i < materials.Length; i++)
        {
            //if (materials[i].name == hitMaterial.name)
            {
                materials[i].color = hitMaterial.color;
                break;
            }
        }
    }
}