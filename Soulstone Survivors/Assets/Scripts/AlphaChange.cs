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
        // �浹�� ���ӿ�����Ʈ�� �÷��̾��� ������ ���
       // if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            // ������ Material�� ���մϴ�.
            Renderer renderer = GetComponentInChildren<Renderer>();
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                if (materials[i].name == hitMaterial.name + " (Instance)")
                {
                    materials[i].color = new Color(materials[i].color.r, materials[i].color.g, materials[i].color.b, 0.5f); // ���İ� ����
                    break;
                }
            }

            // 0.5�� �Ŀ� ���� Material�� �����մϴ�.
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
