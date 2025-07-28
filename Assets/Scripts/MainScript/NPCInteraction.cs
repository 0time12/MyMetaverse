using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject interactionUI;

    [SerializeField]
    private GameObject talkUI;

    private bool isPlayerInRange = false;
    private bool isTalking = false;

    private DialogueController npcDialogue;

    void Start()
    {
        npcDialogue = GetComponent<DialogueController>();
    }

    void Update()
    {
        // 대화가 끝난 후 F를 누르면 닫기
        if (!isTalking && talkUI.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            talkUI.SetActive(false);
        }
        // 범위 안에 있을 때 F키로 대화 진행
        else if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (!isTalking)
            {
                // 대화 시작
                talkUI.SetActive(true);
                npcDialogue.StartDialogue();
                isTalking = true;
            }
            else
            {
                // 대화 중일 때 다음 줄
                bool hasNext = npcDialogue.NextLine();
                if (!hasNext) // 대화가 끝났으면
                {
                    isTalking = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactionUI?.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactionUI?.SetActive(false);
            talkUI?.SetActive(false);
            isTalking = false;
        }
    }
}