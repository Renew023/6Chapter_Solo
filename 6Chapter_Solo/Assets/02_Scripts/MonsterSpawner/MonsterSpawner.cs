using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
	[SerializeField] private Transform spawnPos;
	[SerializeField] private StageInfoPanel stageInfoPanel;

	[SerializeField] private int curStage = 1;
	[SerializeField] private int curRound = 1;
	[SerializeField] private int stageRound = 1;
	[SerializeField] private int spawnCount = 10;
	[SerializeField] private int killCount = 0;

	[SerializeField] private List<StageDataSO> stageDataSO;
	[SerializeField][Range(10f, 20f)] private float minSpawnRadius = 10f;
	[SerializeField][Range(10f, 40f)] private float maxSpawnRadius = 20f;

	public List<StageDataSO> StageDataSO { get => stageDataSO; set => stageDataSO = value; }

	public int killStack = 0;

	void Start()
    {
        spawnPos = StateMachineManager.Instance.Player.transform;
		SpawnEnemy();
	}

	public void Kill()
	{
		killCount += 1;
		stageInfoPanel.UpdateUI(curStage, curRound, spawnCount - killCount);
		if (killCount == spawnCount)
		{
			curRound += 1;
			if (curRound > stageRound)
			{
				curStage += 1;
				curRound = 1;
			}
			if(curStage > stageDataSO.Count)
			{
				curStage = 1; // Reset to first stage if all stages are completed
			}
			Reset();
			SpawnEnemy();
		}
	}

	public void Reset()
	{
		foreach (var enemy in StateMachineManager.Instance.Enemies)
		{
			enemy.gameObject.SetActive(false);
		}
		StateMachineManager.Instance.Enemies.Clear();
		killCount = 0;
	}

	public void SelectStage(int selectStage)
	{
		curStage = selectStage;
		curRound = 1;
		Reset();
		SpawnEnemy();
	}

    public void SpawnEnemy()
    {
		//TODO : 타일에 맞게 몬스터 생성 및 NavMeshAgent 설정
		foreach (var stage in stageDataSO)
		{
			if (stage.stageIndex == curStage)
			{
				spawnCount = stage.rounds[curRound - 1].spawnCount;
				stageRound = stage.rounds.Count;
				stageInfoPanel.UpdateUI(curStage, curRound, spawnCount - killCount);
				for (int i = 0; i < spawnCount; i++)
				{
					Vector2 pos2 = Random.insideUnitCircle.normalized * Random.Range(minSpawnRadius, maxSpawnRadius);
					Vector3 pos = new Vector3(pos2.x, 0, pos2.y);

					Quaternion rot = Quaternion.LookRotation(spawnPos.position - pos);
					int monster= Random.Range(0, stage.rounds[curRound - 1].enemyPrefabs.Count);
					StateMachineManager.Instance.Enemies.Add(Instantiate(stage.rounds[curRound-1].enemyPrefabs[monster], pos, rot));
					StateMachineManager.Instance.Enemies[i].Target = spawnPos;
					StateMachineManager.Instance.Enemies[i].MonsterSpawner = this;
				}
				return;
			}
		}
    }

	public void OnDrawGizmos()
	{
		Handles.color = Color.red;
		Handles.DrawWireDisc(transform.position, Vector3.up, minSpawnRadius);
		Handles.color = Color.green;
		Handles.DrawWireDisc(transform.position, Vector3.up, maxSpawnRadius);
		//Handles.DrawSolidDisc(targetPos.position, Vector3.up, maxSpawnRadius);
		//Handles.DrawSolidDisc(targetPos.position, Vector3.up, maxSpawnRadius);
		//Gizmos.DrawWireSphere(transform.position, minSpawnRadius);
		//Gizmos.color = Color.green;
		//Gizmos.DrawWireSphere(transform.position, maxSpawnRadius);
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(transform.position, spawnPos.position);
		//Gizmos.DrawSphere(targetPos.position, 0.5f);
	}
}
