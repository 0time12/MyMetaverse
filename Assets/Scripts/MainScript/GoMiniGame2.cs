using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMiniGame2 : MonoBehaviour
{
    private bool isPlayerInRange = false;
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.G))
        {
            PlayerPrefs.SetInt("MiniGamePlayed", 2);
            SceneManager.LoadScene("MiniGameScene2");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
