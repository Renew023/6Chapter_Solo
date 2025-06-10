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

	public void TryLoadJson<T>(out T data, string fileName) // Read -> FromJson
	{
		string jsonPath = Application.persistentDataPath + $"{fileName}.json";
		if (File.Exists(jsonPath))
		{
			string jsonData = File.ReadAllText(jsonPath);
			data = JsonUtility.FromJson<T>(jsonData);
		}
		data = default;
	}
}

[SerializeField]
public struct SettingData
{
	public float curBGMVolume;
	public float curSFXVolume;
}

[SerializeField]
public struct InventoryData
{
	public List<InventoryItemData> itemSlot;
}

[SerializeField]
public struct InventoryItemData
{
	public int itemIndex;
	public int value;
}

[SerializeField]
public struct PlayerData
{
	public int playerLevel;
	public int playerExp;
	public int playerGold;
	public int playerMaxHP;
	public int playerCurHP;
	public float AttackDamage;
	public float MoveSpeed;
}

[SerializeField]
public struct StageData
{
	public int curStage;
	public int curRound;
	public int killCount;
}

[SerializeField]
public struct ShopData
{
	public int hpUpLevel;
	public int damageUpLevel;
	public int speedUpLvel;
}


