using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageSlot : MonoBehaviour
{
    [SerializeField] private MonsterSpawner monsterSpawner;
    [SerializeField] private int slotIndex;
    [SerializeField] private TextMeshProUGUI stageLevel;
    [SerializeField] private Button stageSelect;
    public MonsterSpawner MonsterSpawner {set => monsterSpawner = value; }
	public int SlotIndex { set => slotIndex = value; }

	void Start()
    {
        stageLevel.text = "Stage - " + slotIndex;
        stageSelect.onClick.AddListener(() => monsterSpawner.SelectStage(slotIndex));
	}
}
