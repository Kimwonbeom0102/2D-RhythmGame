using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{ 
    private SpriteRenderer theSR;    // ��������Ʈ
    public Sprite defaultImage;      // �⺻�̹���
    public Sprite pressedImage;      // ������ �� �̹���

    public KeyCode keyToPress;       // Ű�Է�

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();  // ����Ƽ �� ��������Ʈ ������
    }

    void Update()
    {
        if(Input.GetKeyDown(keyToPress))   // Ű ������
        {
            theSR.sprite = pressedImage;   // ����� �̹���
        }
        if(Input.GetKeyUp(keyToPress))  
        {  
            theSR.sprite = defaultImage;   // �⺻ �̹���
        }
        
    }
}
