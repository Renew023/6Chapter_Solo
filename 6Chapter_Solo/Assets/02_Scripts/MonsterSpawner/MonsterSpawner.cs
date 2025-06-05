using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private Transform targetPos;
    [SerializeField] private int spawnCount = 5;
	[SerializeField][Range(10f, 20f)] private float minSpawnRadius = 10f;
	[SerializeField][Range(10f, 40f)] private float maxSpawnRadius = 20f;

	void Start()
    {
        targetPos = GameObject.FindObjectOfType<Transform>();
        SpawnEnemy();
	}

    public void SpawnEnemy()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector2 pos2 = Random.insideUnitCircle.normalized * Random.Range(minSpawnRadius, maxSpawnRadius);
            Vector3 pos = new Vector3(pos2.x, 0, pos2.y);

            Quaternion rot = Quaternion.LookRotation(targetPos.position - pos);
            Instantiate(monsterPrefab, pos, rot);
		}
    }
}
