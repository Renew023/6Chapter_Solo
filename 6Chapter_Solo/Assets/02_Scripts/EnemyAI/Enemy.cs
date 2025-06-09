using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ITakeDamage
{
	[SerializeField] private CharacterStatSO originalData;
	[SerializeField] private CharacterStatSO data;
	[SerializeField] private AnimationData animationData;
	[SerializeField] private List<GameObject> itemObjectPrefabs;
	[SerializeField] private GameObject goldPrefabs;
	[SerializeField] private GameObject expPrefabs;


	[SerializeField] private EnemyStateMachine stateMachine;
	[SerializeField] private Animator animator;

	[SerializeField] private Transform target;
	[SerializeField] private Weapon weapon;

	public CharacterStatSO OriginalData { get => data; }
	public CharacterStatSO Data { get => data; set => data = value; }
	public AnimationData AnimationData { get => animationData; }
	public List<GameObject> ItemObjectPrefabs { get => itemObjectPrefabs;  }


	public EnemyStateMachine StateMachine { get => stateMachine; }
	public Animator Animator { get => animator; set => animator = value; }
	public Transform Target { get => target; set => target = value; }
	public Weapon Weapon { get => weapon; }


	void Awake()
	{
		data = Instantiate(originalData);
		data.Init();
		animationData.Initialize();
		animator = GetComponent<Animator>();
		weapon.gameObject.SetActive(false);

		stateMachine = new EnemyStateMachine(this);
		stateMachine.ChangeState(stateMachine.MoveState);
		//초기 상태 스테이트
		//stateMachine.ChangeState(stateMachine);
	}
	//주체 : 상대방의 무기
	public void TakeDamage(float damage)
	{
		float health = data.StatDics[StatType.Health];
		Utility.Print($"현 체력 {health}");
		health = Mathf.Max(health - damage, 0);
		if (health == 0)
		{
			Utility.Print("죽었습니다");
			DropItem();
			stateMachine.ChangeState(stateMachine.DeathState);
			target = null;
			StartCoroutine(DeathCoroutine());
		}
		data.StatDics[StatType.Health] = health;
		Utility.Print($"데미지 이후 체력 {health}");
	}

	private IEnumerator DeathCoroutine()
	{
		yield return new WaitForSeconds(3f);
		gameObject.SetActive(false);
	}
	//주체 : 나
	private void DropItem()
	{
		int b = 30;
		foreach (var item in itemObjectPrefabs)
		{
			int a = Random.Range(0, 100);
			if (a > b)
			{
				Utility.Print("드랍");
				Vector2 pos2 = Random.insideUnitCircle.normalized * Random.Range(0f, 0.5f);
				Vector3 pos = gameObject.transform.position + new Vector3(pos2.x, 0, pos2.y);
				Instantiate(item, pos, Quaternion.identity);
				b += 10;
			}
		}
		for(int i=0; i < data.StatDics[StatType.Gold]; i+=10)
		{
				Utility.Print("골드 드랍");
				Vector2 pos2 = Random.insideUnitCircle.normalized * Random.Range(0f, 0.5f);
				Vector3 pos = gameObject.transform.position + new Vector3(pos2.x, 0, pos2.y);
				Instantiate(goldPrefabs, pos, Quaternion.identity); // Assuming the first prefab is gold
		}
		for (int i = 0; i < data.StatDics[StatType.Exp]; i += 10)
		{
			Utility.Print("경험치 드랍");
			Vector2 pos2 = Random.insideUnitCircle.normalized * Random.Range(0f, 0.5f);
			Vector3 pos = gameObject.transform.position + new Vector3(pos2.x, 0, pos2.y);
			Instantiate(expPrefabs, pos, Quaternion.identity); // Assuming the first prefab is gold
		}
	}
}
