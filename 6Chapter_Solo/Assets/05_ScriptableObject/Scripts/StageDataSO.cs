using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "ScriptableObjects/StageData")]
public class StageDataSO : ScriptableObject
{
    public int stageIndex;
    public List<Round> rounds;
}

[Serializable]
public class Round
{
	public int spawnCount;
	public List<Enemy> enemyPrefabs;
}