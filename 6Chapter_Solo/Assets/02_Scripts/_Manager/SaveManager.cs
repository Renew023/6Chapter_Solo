using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
	// Start is called before the first frame update
	protected override void Awake()
	{
		DontDestroyOnLoad(gameObject);
		base.Awake();
	}

	public void SaveJson<T>(T data, string fileName) // -> ToJson -> Write
	{
		string jsonData = JsonUtility.ToJson(data);
		string jsonPath = Application.persistentDataPath + $"{fileName}.json";

		File.WriteAllText(jsonPath, jsonData);
	}

	public bool TryLoadJson<T>(out T data, string fileName) // Read -> FromJson
	{
		string jsonPath = Application.persistentDataPath + $"{fileName}.json";
		if (File.Exists(jsonPath))
		{
			string jsonData = File.ReadAllText(jsonPath);
			data = JsonUtility.FromJson<T>(jsonData);
			return true;
		}
		data = default;
		return false;
	}
}

[System.Serializable]
public struct SettingData
{
	public float curBGMVolume;
	public float curSFXVolume;
}

[System.Serializable]
public class InventoryData
{
	public List<InventoryItemData> itemSlot;
}

[System.Serializable]
public class InventoryItemData
{
	public int itemIndex;
	public int value;
}

[System.Serializable]
public class PlayerData
{
	public int playerLevel;
	public int playerExp;
	public int playerGold;
	public int playerMaxHP;
	public int playerCurHP;
	public float AttackDamage;
	public float MoveSpeed;
}

[System.Serializable]
public class StageData
{
	public int curStage;
	public int curRound;
	public int killCount;
}

[System.Serializable]
public class ShopData
{
	public int hpUpLevel;
	public int damageUpLevel;
	public int speedUpLvel;
}


