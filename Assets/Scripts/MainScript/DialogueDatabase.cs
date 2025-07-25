using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DialogueDatabase
{
    public static Dictionary<string, string[]> npcDialogues
        = new Dictionary<string, string[]>()
    {
        { "NPC1", new string[] {
            "�ݰ��� ��翩",
            "����Գ�"
        }},

        { "NPC2", new string[] {
            "�̰������� �̴ϰ���1�� �� �� �ֽ��ϴ�",
            "���ƶ� ����� ���� :",
            "���콺 Ŭ�� Ȥ�� �����̽��� ����⸦",
            "������ �� �ֽ��ϴ�.",
            "�����Ͻðڽ��ϱ�? ����:G"
        }},

        { "NPC3", new string[] {
            "�̰��� �̴ϰ���2�� ���°��̾�...",
            "���� ������ ���� :",
            "���콺 Ŭ������ ���� ������...",
            "����� �ִ� ���� ��� ���߸� ����...",
            "�װ� �̹� ���� ���� ���߸� ����...",
            "�����ҷ�?...\n ����:G"
        }}

    };

}
