using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DialogueDatabase
{
    public static Dictionary<string, string[]> npcDialogues
        = new Dictionary<string, string[]>()
    {
        { "NPC1", new string[] {
            "반갑네 용사여",
            "어서오게나"
        }},

        { "NPC2", new string[] {
            "이곳에서는 미니게임1에 들어갈 수 있습니다",
            "날아라 비행기 설명 :",
            "마우스 클릭 혹은 스페이스로 비행기를",
            "조종할 수 있습니다.",
            "시작하시겠습니까? 수락:G"
        }},

        { "NPC3", new string[] {
            "이곳은 미니게임2로 가는곳이야...",
            "공을 던져라 설명 :",
            "마우스 클릭으로 공을 던져봐...",
            "가운데에 있는 공에 모두 맞추면 성공...",
            "네가 이미 던진 공에 맞추면 실패...",
            "시작할래?...\n 수락:G"
        }}

    };

}
