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
        int played = PlayerPrefs.GetInt("MiniGamePlayed", 0); // 어떤 미니게임인지
        int score = PlayerPrefs.GetInt("CurrentScore", 0);     // 미니게임1 최종 점수
        int successcheck = PlayerPrefs.GetInt("SuccessCheck", 0); // 미니게임2 성공 여부

        if (played == 1)
        {
            Debug.Log("score : " + score);
            panel.SetActive(true);

            if (score >= 20) // 성공
            {
                failText.SetActive(false);
                
            }
            else if (score < 20) // 실패
            {
                successText.SetActive(false);
            }


        }
        else if (played == 2)
        {
            Debug.Log("successcheck : "+ successcheck);
            panel.SetActive(true);

            if (successcheck == 2) // 성공
            {
                 failText.SetActive(false);
            }
            else if (successcheck == 1) // 실패
            {
                successText.SetActive(false);
            }
            else if (successcheck == 0) // 실패
            {
                panel.SetActive(false);
            }

        }
        else
        {
            // 미니게임 기록이 없으면 패널 숨김
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