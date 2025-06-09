using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStatSO", menuName = "ScriptableObjects/CharacterStat")]
public class CharacterStatSO : ScriptableObject
{
	public List<StatData> Stats;
	public Dictionary<StatType, float> StatDics;

	public void Init()
	{
		foreach(StatData stat in Stats)
		{
			if (StatDics == null)
			{
				StatDics = new Dictionary<StatType, float>();
			}
			StatDics[stat.StatType] = stat.BaseValue;
		}
	}
}

[Serializable]
public class StatData
{
	public StatType StatType;
	public float BaseValue;
}
