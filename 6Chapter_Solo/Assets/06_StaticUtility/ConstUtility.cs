using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AnimationData
{
	[SerializeField] private string idleParamenterName = "Idle";
	[SerializeField] private string findParameterName = "Find";
	[SerializeField] private string moveParameterName = "Move";
	[SerializeField] private string attackParameterName = "Attack";
	[SerializeField] private string deathParameterName ="Death";


	public int IdleParameterHash { get; private set; }
	public int FindParameterHash { get; private set; }
	public int MoveParameterHash { get; private set; }
	public int AttackParameterHash { get; private set; }
	public int DeathParameterHash { get; private set; }

	public void Initialize()
	{
		IdleParameterHash = Animator.StringToHash(idleParamenterName);
		FindParameterHash = Animator.StringToHash(findParameterName);
		MoveParameterHash = Animator.StringToHash(moveParameterName);
		AttackParameterHash = Animator.StringToHash(attackParameterName);
		DeathParameterHash = Animator.StringToHash(deathParameterName);
	}
}

[SerializeField]
public class SaveData
{
	[SerializeField] private string settingDataName = "SettingData";
	[SerializeField] private string inventoryDataName = "InventoryData";
	[SerializeField] private string playerDataName = "PlayerData";
	[SerializeField] private string stageDataName = "StageData";
	[SerializeField] private string shopDataName = "ShopData";

	public string SettingDataName { get => settingDataName; }
	public string InventoryDataName { get => inventoryDataName; }
	public string PlayerDataName { get => playerDataName; }
	public string StageDataName { get => stageDataName; }
	public string ShopDataName { get => shopDataName; }
}
