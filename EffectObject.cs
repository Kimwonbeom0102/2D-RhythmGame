using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour  // ����Ʈ�� �Ҵ�
{
    public float deletetime = 1f;
    void Start()
    {
        
    }

    
    void Update()
    {
        Destroy(gameObject, deletetime);  // 1�ʵ� ����Ʈ ����
    }
}
