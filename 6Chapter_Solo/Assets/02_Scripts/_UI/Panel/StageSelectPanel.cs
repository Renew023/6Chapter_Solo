using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectPanel : MonoBehaviour
{
	[SerializeField] private MonsterSpawner stageDataList;

	[SerializeField] private GameObject stageSelectButtonPrefab;
	[SerializeField] private List<GameObject> prefabList;
	[SerializeField] private Transform prefabParent;
	[SerializeField] private Button closeButton;

	void Awake()
	{
		for (int i = 0; i < stageDataList.StageDataSO.Count; i++)
		{
			prefabList.Add(Instantiate(stageSelectButtonPrefab, prefabParent));
			prefabList[i].GetComponent<StageSlot>().MonsterSpawner = stageDataList;
			prefabList[i].GetComponent<StageSlot>().SlotIndex = stageDataList.StageDataSO[i].stageIndex;
		}
		closeButton.onClick.AddListener(() => gameObject.SetActive(false));
	}
}
