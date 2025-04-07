using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour  
{
    public AudioSource theMusic;  // ���Ǽҽ�

    public bool startPlaying;     // ���ӽ�ŸƮ

    public NoteHolderManager theNH;  //  ��ƮȦ��

    public static GameManager instance;  // �ν��Ͻ� ����

    public int currentScore;   // �������� �ۺ����� �־��־ ���ھ �� �� ����

    public int scorePerNote = 100;  //  �� ��Ʈ�� 100������ ����Ͽ� ��Ʈ�� ĥ������ NoteHit �Լ��� ���ھ �����Ͽ� ���� ���ھ ��������.  Normal ��Ʈ ���ھ�
    public int scorePerGoodNote = 125;   // Good ��Ʈ ���ھ�
    public int scorePerPerfectNote = 150;  // Perfect ��Ʈ ���ھ�

    public int currentMultiplier;    // ���� X
    public int multiplierTracker;    // ���� 
    public int[] multiplierThresholds;  

    public Text scoreText;
    public Text multiText;
    

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHIts;

    public GameObject resultsScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    void Start()
    {
        instance = this;  // �̱��� 

        scoreText.text = "Score: 0";  
        currentMultiplier = 1;  // 1�� ����

        totalNotes = FindObjectsOfType<NoteObject>().Length; // �� ��Ʈ
    }

    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown) // �����Ҷ� Ű�Է�
            {
                startPlaying = true;  // ����
                theNH.hasStarted = true;  

                theMusic.Play();
            }
        }
        else
        {
            if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);  //  ��ũ������

                normalsText.text = "" + normalHits;
                goodsText.text = goodHits.ToString();
                percentHitText.text = perfectHits.ToString();
                missesText.text = "" + missedHIts;

                float totalHit = normalHits + goodHits + perfectHits; // �� Hit
                float percentHit = (totalHit / totalNotes) * 100f;   // ������� �ۼ�Ƽ�� ����

                percentHitText.text = percentHit.ToString("F1") + "%"; // ����� ��� %

                string rank = "F";  // �⺻ ��ũ F

                if(percentHit > 50)  
                {
                    rank = "D";
                    if(percentHit > 60)
                    {
                        rank = "C";
                        if(percentHit > 80)
                        {
                            rank = "B";
                            if(percentHit > 90)
                            {
                                rank = "A";
                                if(percentHit > 95)  // ���������� D~S ��ũ
                                {
                                    rank = "S";
                                }
                            }
                        }
                    }
                }
                rankText.text = rank;
                finalScoreText.text = currentScore.ToString();   
            }
        }
    }

    public void NoteHit()
    {
        //Debug.Log("Hit");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {

            multiplierTracker++;  // Ʈ��Ŀ�� ����� ���� �÷���

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;  // ����� �ʱ�ȭ
                currentMultiplier++;
            }

        }

        multiText.text = "Multiplier: x " + currentMultiplier;
        
        //currentScore += scorePerNote * currentMultiplier;   //  ��Ʈ �ϳ��� ������ �����־� ���� ������ ����
        scoreText.text = "Score: " + currentScore;
          
    }

    public void NormalHit()
    {  
        currentScore += scorePerNote * currentMultiplier;  // ���� ��� x ��Ʈ 
        NoteHit();

        normalHits++;
    }
    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;  // ���� ��� x good��Ʈ 
        NoteHit();
        goodHits++;
    }
    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;  // ���� ���  x per��Ʈ
        NoteHit();
        perfectHits++;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed");

        currentMultiplier = 1;  // �ʱ�ȭ
        multiplierTracker = 0;  // �ʱ�ȭ

        multiText.text = "Multiplier: x " + currentMultiplier;
        missedHIts++;
    }
}
