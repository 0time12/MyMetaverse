using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI bestscoreText;

    [SerializeField]
    private TextMeshProUGUI bestscoreTextb;

    [SerializeField]
    private Button restartbutton;

    [SerializeField]
    private Button mainbutton;

    [SerializeField]
    private TextMeshProUGUI countdownText;

    [SerializeField]
    private GameObject playerController;

    public float delayBetweenCounts = 1f;

    public void Start()
    {
        if (bestscoreText == null)
        {
            Debug.LogError("restart text is null");
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            return;
        }

        if (playerController != null)
            playerController.SetActive(false);

        StartCoroutine(CountdownRoutine());

        bestscoreText.gameObject.SetActive(false);
        bestscoreTextb.gameObject.SetActive(false);
        restartbutton.gameObject.SetActive(false);
        mainbutton.gameObject.SetActive(false);
    }

    public void SetRestart()
    {
        bestscoreText.gameObject.SetActive(true);
        bestscoreTextb.gameObject.SetActive(true);
        restartbutton.gameObject.SetActive(true);
        mainbutton.gameObject.SetActive(true);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void UpdateBestScore(int bestscore)
    {
        bestscoreText.text = bestscore.ToString();
    }

    IEnumerator CountdownRoutine()
    {
        countdownText.gameObject.SetActive(true);

        int count = 3;
        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(delayBetweenCounts);
            count--;
        }

        countdownText.text = "Start!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);

        if (playerController != null)
            playerController.SetActive(true);
    }

}