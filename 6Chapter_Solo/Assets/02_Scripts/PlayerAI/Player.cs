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
	[SerializeField] private CharacterStatSO originalData;
	[SerializeField] private CharacterStatSO maxData;
    [SerializeField] private CharacterStatSO data; //curData;
	[SerializeField] public List<ItemEquip> itemEquip = new List<ItemEquip>();
	[SerializeField] private AnimationData animationData;

    [SerializeField] private PlayerStateMachine stateMachine;
	[SerializeField] private Animator animator;

    [SerializeField] private Transform target;
	[SerializeField] private Weapon weapon;

	public CharacterStatSO OriginalData { get => data; }
	public CharacterStatSO MaxData {get => maxData; set => maxData = value; }
	public CharacterStatSO Data { get => data; set => data = value; }
	public AnimationData AnimationData { get => animationData; }

    public PlayerStateMachine StateMachine { get => stateMachine; }

	public Animator Animator { get => animator; }
    public Transform Target { get => target; set => target = value; }
	public Weapon Weapon { get => weapon; }

	void Awake()
	{
		StateMachineManager.Instance.Player = this;
		data = Instantiate(originalData);
		maxData = Instantiate(originalData);
		data.Init();
		maxData.Init();
		animationData.Initialize();
		animator = GetComponent<Animator>();
		weapon.gameObject.SetActive(false);

		stateMachine = new PlayerStateMachine(this);
		//초기 상태 스테이트
		stateMachine.ChangeState(stateMachine.FindTargetState);
	}

	public void TakeDamage(float damage)
	{
		float health = data.StatDics[StatType.Health];
		Utility.Print($"현 체력 {health}");
		health = Mathf.Max(health - damage, 0);
		if (health == 0)
		{
			Utility.Print("죽었습니다");
			Time.timeScale = 0f;
			stateMachine.ChangeState(stateMachine.DeathState);
			target = null;
		}
		data.StatDics[StatType.Health] = health;
		//TODO : 개선 요망 [ 인벤토리 구조 이상함 ]
		Inventory.Instance.playerStatPanel.HpUIReload();

		Utility.Print($"데미지 이후 체력 {health}");
	}
}
