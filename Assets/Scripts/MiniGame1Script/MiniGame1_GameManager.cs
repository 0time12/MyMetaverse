using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGame1_GameManager : MonoBehaviour
{
    static MiniGame1_GameManager gameManager;

    public static MiniGame1_GameManager Instance
    {
        get { return gameManager; }
    }

    private int currentScore = 0;
    

    UIManager uiManager;

    public UIManager UIManager
    {
        get { return uiManager; }
    }
    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager.UpdateScore(0);
        uiManager.UpdateBestScore(PlayerPrefs.GetInt("Mini1BestScore", 0));
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        Mini1BestScore();
        uiManager.SetRestart();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        uiManager.UpdateScore(currentScore);

        //���ο��� �������� �Ǵ��ϱ� ���� ���� ����
        int savecurrent = PlayerPrefs.GetInt("CurrentScore", 0);

        if (currentScore > savecurrent)
        {
            savecurrent = currentScore;
            PlayerPrefs.SetInt("CurrentScore", currentScore-1);
        }

    }

    public void Mini1BestScore()
    {
        int savedBest = PlayerPrefs.GetInt("Mini1BestScore", 0);
        int bestscore = 0;

        if (currentScore > savedBest)
        {
            PlayerPrefs.SetInt("Mini1BestScore", currentScore);
            PlayerPrefs.Save();
            bestscore = currentScore;
        }
        else
        {
            bestscore = savedBest;
        }
        uiManager.UpdateBestScore(bestscore);
        Debug.Log("Best Score: " + bestscore);
    }



}