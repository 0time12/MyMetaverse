using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MiniGameResultUI : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private GameObject successText;

    [SerializeField]
    private GameObject failText;

    [SerializeField]
    private GameObject closeButton;

    private void Start()
    {
        int played = PlayerPrefs.GetInt("MiniGamePlayed", 0); // � �̴ϰ�������
        int score = PlayerPrefs.GetInt("CurrentScore", 0);     // �̴ϰ���1 ���� ����
        int successcheck = PlayerPrefs.GetInt("SuccessCheck", 0); // �̴ϰ���2 ���� ����

        if (played == 1)
        {
            Debug.Log("score : " + score);
            panel.SetActive(true);

            if (score >= 20) // ����
            {
                failText.SetActive(false);
                
            }
            else if (score < 20) // ����
            {
                successText.SetActive(false);
            }


        }
        else if (played == 2)
        {
            Debug.Log("successcheck : "+ successcheck);
            panel.SetActive(true);

            if (successcheck == 2) // ����
            {
                 failText.SetActive(false);
            }
            else if (successcheck == 1) // ����
            {
                successText.SetActive(false);
            }
            else if (successcheck == 0) // ����
            {
                panel.SetActive(false);
            }

        }
        else
        {
            // �̴ϰ��� ����� ������ �г� ����
            panel.SetActive(false);
        }



    }

    public void ClosePanel()
    {
        PlayerPrefs.DeleteKey("CurrentScore");
        PlayerPrefs.DeleteKey("SuccessCheck");
        PlayerPrefs.DeleteKey("MiniGamePlayed");
        panel.SetActive(false);
    }
}