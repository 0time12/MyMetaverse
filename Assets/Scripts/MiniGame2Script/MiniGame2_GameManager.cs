using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniGame2_GameManager : MonoBehaviour
{
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

    [SerializeField]
    private TextMeshProUGUI TimeText;

    float time = 0f;

    [SerializeField]
    private TextMeshProUGUI countdownText;

    public bool isCountingDown = false;

    [SerializeField]
    private GameObject player;

    public float delayBetweenCounts = 1f;

    public bool isGameOver = false;

    public static MiniGame2_GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        if (player != null)
            player.SetActive(false);

        StartCoroutine(CountdownRoutine());
        textgoal.SetText(goal.ToString());
    }

    private void Update()
    {
        if (isCountingDown)
        {
            time += Time.deltaTime;
            TimeText.text = time.ToString("N2");
        }
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
            isCountingDown = false;

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

        if (player != null)
            player.SetActive(true);

        isCountingDown = true;
    }
}
