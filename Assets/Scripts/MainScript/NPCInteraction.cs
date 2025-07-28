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
        // ��ȭ�� ���� �� F�� ������ �ݱ�
        if (!isTalking && talkUI.activeSelf && Input.GetKeyDown(KeyCode.F))
        {
            talkUI.SetActive(false);
        }
        // ���� �ȿ� ���� �� FŰ�� ��ȭ ����
        else if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (!isTalking)
            {
                // ��ȭ ����
                talkUI.SetActive(true);
                npcDialogue.StartDialogue();
                isTalking = true;
            }
            else
            {
                // ��ȭ ���� �� ���� ��
                bool hasNext = npcDialogue.NextLine();
                if (!hasNext) // ��ȭ�� ��������
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