using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemEquip
{
	public EquipType equipType;
	public int itemIndex;
	public bool isEquip;
}

public class Player : MonoBehaviour, ITakeDamage
{
	[SerializeField] private int maxHealth;
	[SerializeField] private CharacterStatSO originalData;
    [SerializeField] private CharacterStatSO data; //curData;
	[SerializeField] private PlayerData playerData;

	[SerializeField] public List<ItemEquip> itemEquip = new List<ItemEquip>();
	[SerializeField] private AnimationData animationData;
	[SerializeField] private SaveData saveData;

    [SerializeField] private PlayerStateMachine stateMachine;
	[SerializeField] private Animator animator;

    [SerializeField] private Transform target;
	[SerializeField] private Weapon weapon;

	public CharacterStatSO OriginalData { get => originalData; }
	public CharacterStatSO Data { get => data;
		set {
			data = value;
			Debug.Log("덮어쓰기 되었습니다.");
			PlayerDataSave(); } 
	}
	public AnimationData AnimationData { get => animationData; }

	public int MaxHealth
	{
		get => maxHealth;
		set
		{
			Data.StatDics[StatType.Health] += value - maxHealth;
			maxHealth = value;
			PlayerDataSave();
		}
	}

	public PlayerStateMachine StateMachine { get => stateMachine; }

	public Animator Animator { get => animator; }
    public Transform Target { get => target; set => target = value; }
	public Weapon Weapon { get => weapon; }

	void Awake()
	{
		StateMachineManager.Instance.Player = this;
		data = Instantiate(originalData);
		data.Init();
		//왜 값이 안들어가는지 모르겠으나, 일단 보류
		PlayerDataLoad();
		animationData.Initialize();
		animator = GetComponent<Animator>();
		maxHealth = (int)data.StatDics[StatType.Health];
		//불러오기 전에, Dictionary의 값에 문제가 있는듯함.

		weapon.gameObject.SetActive(false);

		stateMachine = new PlayerStateMachine(this);
		//초기 상태 스테이트
		stateMachine.ChangeState(stateMachine.FindTargetState);
	}

	public void PlayerDataLoad()
	{
		if (SaveManager.Instance.TryLoadJson(out playerData, saveData.PlayerDataName))
		{
			MaxHealth = playerData.playerMaxHP;
			data.StatDics[StatType.Health] = playerData.playerMaxHP;
			data.StatDics[StatType.Level] = playerData.playerLevel;
			data.StatDics[StatType.Exp] = playerData.playerExp;
			data.StatDics[StatType.Gold] = playerData.playerGold;
			data.StatDics[StatType.Attack] = playerData.AttackDamage;
			data.StatDics[StatType.MoveSpeed] = playerData.MoveSpeed;
		}
	}

	public void PlayerDataSave()
	{
		// 데이터 저장 시점 : 레벨업 시, 아이템 구매 시, 피해 입을 시
		playerData.playerMaxHP = MaxHealth;
		playerData.playerCurHP = (int)data.StatDics[StatType.Health];
		playerData.playerLevel = (int)data.StatDics[StatType.Level];
		playerData.playerExp = (int)data.StatDics[StatType.Exp];
		playerData.playerGold = (int)data.StatDics[StatType.Gold];
		playerData.AttackDamage = (int)data.StatDics[StatType.Attack];
		playerData.MoveSpeed = (int)data.StatDics[StatType.MoveSpeed];
		SaveManager.Instance.SaveJson(playerData, saveData.PlayerDataName);
	}

	public void TakeDamage(float damage)
	{
		float health = data.StatDics[StatType.Health];
		Utility.Print($"현 체력 {health}");
		health = Mathf.Max(health - damage, 0);
		data.StatDics[StatType.Health] = health;
		if (health == 0)
		{
			Utility.Print("죽었습니다");
			Time.timeScale = 0f;
			stateMachine.ChangeState(stateMachine.DeathState);
			target = null;
		}
		//TODO : 개선 요망 [ 인벤토리 구조 이상함 ]
		Inventory.Instance.playerStatPanel.HpUIReload();

		Utility.Print($"데미지 이후 체력 {health}");
	}
}
