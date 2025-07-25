using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniGame2_GameManager : MonoBehaviour
{
    public static MiniGame2_GameManager instance = null;
    public bool isGameOver = false;

    [SerializeField]
    private TextMeshProUGUI textgoal;

    [SerializeField]
    public int goal;

    [SerializeField]
    private Color green;

    [SerializeField]
    private Color red;

    [SerializeField]
    private GameObject retrybtn;

    [SerializeField]
    private GameObject mainbtn;

    private void Awake()
    {
        if (instance == null)
            instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        textgoal.SetText(goal.ToString());
    }

    public void Decreasegoal()
    {
        goal -= 1;
        textgoal.SetText(goal.ToString());
        if (goal <= 0)
        {
            SetGameOver(true);
        }
    }
    public void SetGameOver(bool success)
    {
        int successcheck;

        if (isGameOver == false)
        {
            isGameOver = true;

            Camera.main.backgroundColor = success ? green : red;
            Invoke("ShowRetryButton", 0.5f);

            successcheck = success ? 2 : 1;

            PlayerPrefs.SetInt("SuccessCheck", successcheck);

        }
    }

    void ShowRetryButton()
    {
        mainbtn.SetActive(true);
        retrybtn.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("MiniGameScene2");
    }

    public void main()
    {
        SceneManager.LoadScene("MainScene");
    }
}
