using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��¥ : 2021-01-18 PM 4:52:11
// �ۼ��� : Rito

[Serializable]
public class AfterImageData
{
    [Range(0.1f, 2.0f), Tooltip("�ܻ� ���� �ð�")]
    public float duration = 1.0f;

    public string shaderColorName = "_Color";
    public string shaderAlphaName = "_Alpha";

    public Material Mat { get; set; }
}