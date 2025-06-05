using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStatSO", menuName = "ScriptableObjects/CharacterStat")]
public class CharacterStatSO : ScriptableObject
{
	public List<StatData> stats;
	public Dictionary<StatType, int> statDics;

	public void Init()
	{
		foreach(StatData stat in stats)
		{
			if (statDics == null)
			{
				statDics = new Dictionary<StatType, int>();
			}
			statDics[stat.statType] = stat.baseValue;
		}
	}
	public int GetBaseValue(StatType statType)
	{
		Init();
		return statDics.TryGetValue(statType, out var value) ? value : 0;
	}

}

[Serializable]
public class StatData
{
	public StatType statType;
	public int baseValue;
}
