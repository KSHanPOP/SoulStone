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

    void OnCollisionEnter(Collision collision)
    {
        // 충돌한 게임오브젝트가 플레이어의 공격일 경우
       // if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            // 적용할 Material을 구합니다.
            Renderer renderer = GetComponentInChildren<Renderer>();
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                if (materials[i].name == hitMaterial.name + " (Instance)")
                {
                    materials[i].color = new Color(materials[i].color.r, materials[i].color.g, materials[i].color.b, 0.5f); // 알파값 변경
                    break;
                }
            }

            // 0.5초 후에 원래 Material로 변경합니다.
            Invoke("RestoreMaterial", 0.5f);
        }
    }

    private void RestoreMaterial()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material[] materials = renderer.materials;
        for (int i = 0; i < materials.Length; i++)
        {
            if (materials[i].name == hitMaterial.name + " (Instance)")
            {
                materials[i].color = defaultMaterial.color;
                break;
            }
        }
    }
}
