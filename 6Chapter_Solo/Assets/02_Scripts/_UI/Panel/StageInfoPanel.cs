using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageInfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI RoundInfo;
    [SerializeField] private TextMeshProUGUI MonsterValue;

    public void UpdateUI(int curStage, int curRound, int monsterValue)
    {
        RoundInfo.text = curStage + " - " + curRound;
		MonsterValue.text = monsterValue.ToString();
    }
}
