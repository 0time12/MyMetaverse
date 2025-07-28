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
        // 다음 줄이 존재하는지 체크
        if (currentIndex + 1 < lines.Length)
        {
            currentIndex++;
            dialogueText.text = lines[currentIndex];
            return true;  // 아직 대사가 남아있음
        }
        else
        {
            EndDialogue();  // 대화 종료
            return false;   
        }
    }

    public void EndDialogue()
    {
        talkUI?.SetActive(false);
    }
}