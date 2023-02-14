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

    // 다른 스크립트에서 필요한 UI를 업데이트하는 메서드들
    public void UpdateHealthBar(float value)
    {
        // healthBar를 업데이트하는 코드
    }

    public void UpdateHealthText(int value)
    {
        // scoreText를 업데이트하는 코드
    }

    // 기타 필요한 메서드들
}
