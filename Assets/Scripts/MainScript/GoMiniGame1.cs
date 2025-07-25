using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMiniGame1 : MonoBehaviour
{
    private bool isPlayerInRange = false;
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.G))
        {
            PlayerPrefs.SetInt("MiniGamePlayed", 1);
            SceneManager.LoadScene("MiniGameScene1");
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
