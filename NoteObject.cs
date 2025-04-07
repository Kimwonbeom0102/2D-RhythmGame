using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class NoteObject : MonoBehaviour
{
    public bool isPressed;
    public KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    

    


    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(isPressed)
            {
                gameObject.SetActive(false);  // ��ư�� ������ ��ư�� ����� (�ı���, Ȱ��ȭ �ȵ�)

                //GameManager.instance.NoteHit();  // ���ӸŴ������� ���� ��Ʈ�� �ƴٴ°� �־���.  ���ӸŴ����� ��Ʈ�Լ��� ������־ �븻,��,����Ʈ�� ������ ����Ұ��̱⿡ �ּ�ó���ϰ�

                if (Mathf.Abs(transform.position.y) > 0.25)  // ������ �ɾ��־�
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();   // ���ӸŴ������� �븻�Լ��� ȣ��(�ν��Ͻ�)
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    
                    

                }
                else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();  // ���ӸŴ������� ���Լ��� ȣ��(�ν��Ͻ�)
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    

                }
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit(); // ���ӸŴ������� ����Ʈ�Լ��� ȣ��(�ν��Ͻ�)
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    

                }



            }
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other) // ��Ʈ ���� ��
    {
        if(other.tag == "Activator")  // Ȱ��ȭ��Ű��
        {
            isPressed = true;         // �Է°���
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)  // ��Ʈ �̽�(��Ʈ ���Դٰ� ���� ��)
    {
        if(other.tag == "Activator" && isPressed == false)  // �±��ϰ�, ������ �������
        {
            Debug.Log("�����ƽ��ϴ�.");

            GameManager.instance.NoteMissed();  // ��ģ���� ���ӸŴ������� ����
            Debug.Log("���ӸŴ��� ������");
            Instantiate(missEffect, transform.position, missEffect.transform.rotation); // �̽�����Ʈ
            
        }
        else if(other.tag == "Missjudgement") // �׳� �����°��
        {
            GameManager.instance.NoteMissed();
            Debug.Log("Die Zone �� ��ҽ��ϴ�..");
            Instantiate(missEffect, transform.position, missEffect.transform.rotation); // �̽�����Ʈ
        }
        
    }
    

}
