using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private Enemy monsterPrefab;
	[SerializeField] private Transform spawnPos;
    [SerializeField] private int spawnCount = 5;
	[SerializeField][Range(10f, 20f)] private float minSpawnRadius = 10f;
	[SerializeField][Range(10f, 40f)] private float maxSpawnRadius = 20f;

	void Start()
    {
        spawnPos = StateMachineManager.Instance.Player.transform;
		SpawnEnemy();
	}

    public void SpawnEnemy()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector2 pos2 = Random.insideUnitCircle.normalized * Random.Range(minSpawnRadius, maxSpawnRadius);
            Vector3 pos = new Vector3(pos2.x, 0, pos2.y);

            Quaternion rot = Quaternion.LookRotation(spawnPos.position - pos);
            StateMachineManager.Instance.Enemies.Add(Instantiate(monsterPrefab, pos, rot));
			StateMachineManager.Instance.Enemies[i].Target = spawnPos;
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
