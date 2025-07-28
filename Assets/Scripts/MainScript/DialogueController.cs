using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    private Text dialogueText;

    [SerializeField]
    private GameObject talkUI;

    private string[] lines;
    private int currentIndex = 0;
    private bool isTalking = false;

    void Start()
    {
        string npcName = gameObject.name;
        if (DialogueDatabase.npcDialogues.ContainsKey(npcName))
            lines = DialogueDatabase.npcDialogues[npcName];
        else
            lines = new string[] { "..." };
    }

    public void StartDialogue()
    {
        if (lines == null || lines.Length == 0)
        {
            dialogueText.text = "";
            return;
        }

        currentIndex = 0;
        dialogueText.text = lines[currentIndex];
        isTalking = true;

        if (talkUI != null) talkUI.SetActive(true);
    }

    public bool NextLine()
    {
        // ���� ���� �����ϴ��� üũ
        if (currentIndex + 1 < lines.Length)
        {
            currentIndex++;
            dialogueText.text = lines[currentIndex];
            return true;  // ���� ��簡 ��������
        }
        else
        {
            EndDialogue();  // ��ȭ ����
            return false;   
        }
    }

    public void EndDialogue()
    {
        talkUI?.SetActive(false);
    }
}