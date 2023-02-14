using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject healthBar;
    public GameObject healthText;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �ٸ� ��ũ��Ʈ���� �ʿ��� UI�� ������Ʈ�ϴ� �޼����
    public void UpdateHealthBar(float value)
    {
        // healthBar�� ������Ʈ�ϴ� �ڵ�
    }

    public void UpdateHealthText(int value)
    {
        // scoreText�� ������Ʈ�ϴ� �ڵ�
    }

    // ��Ÿ �ʿ��� �޼����
}
