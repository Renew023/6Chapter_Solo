using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum TileType
{
	Grass,
	Water,
	Sand,
	Rock
}

public class MapBuild : MonoBehaviour
{
	private Random.State originalState;

	[SerializeField] private List<TileData> tileDatas;
	private Dictionary<TileType, GameObject> tilePrefabs = new();

	[Header("맵 정보")]
	[SerializeField] private int mapSize;
	[SerializeField] private int randomSeed;
	[SerializeField] private int curX = 0;
	[SerializeField] private int curY = 0;
	[SerializeField] private int prefabSize = 5;
	[SerializeField] private Dictionary<GridData, TileType> grid = new();

	public List<GameObject> Map;

	private void InitializeMap()
	{
		foreach (var entry in tileDatas)
		{
			tilePrefabs.Add(entry.type, entry.prefab);
		}
	}

	void Awake()
	{
		//TODO : NavMeshBake 설정. -> 부모 오브젝트를 만들어서 NavMeshBake 해도 가능.
		originalState = Random.state;
		InitializeMap();
		CreateGrid();
		CreatePrefabs();
		Random.state = originalState;
	}
	private void CreatePrefabs()
	{
		foreach(var entry in grid)
		{
			GridData gridData = entry.Key;
			TileType tileType = entry.Value;

			GameObject prefab = tilePrefabs[tileType];
			Vector3 position = new Vector3(gridData.x * prefabSize, 0, gridData.z * prefabSize);

			Map.Add(Instantiate(prefab, position, Quaternion.identity));
		}
	}
	
	private void CreateGrid()
	{
		int direction = 0;
		Random.InitState(randomSeed);

		TileType startTile = (TileType)Random.Range(0, tileDatas.Count);
		GridData startPos = new GridData { x = curX, z = curY };
		grid[startPos] = startTile;

		for (int map = 0; map < mapSize; map++)
		{
			int count = 0;
			int check = 20;
			int radius = 1;

			while (true)
			{
				direction = Random.Range(0, 4);
				TileType tile = (TileType)Random.Range(0, tileDatas.Count);

				int nextX = curX;
				int nextY = curY;

				switch (direction)
				{
					case 0: nextX = curX + radius; break;
					case 1: nextX = curX - radius; break;
					case 2: nextY = curY + radius; break;
					case 3: nextY = curY - radius; break;
				}

				GridData gridPos = new GridData { x = nextX, z = nextY };

				if (!grid.ContainsKey(gridPos))
				{
					curX = nextX;
					curY = nextY;
					grid.Add(gridPos, tile);
					break;
				}
				count++;
				if (check <= count)
				{
					radius += 1;
					count = 0;
				}
			}
			//if (grid.ContainsKey(new GridData { x = curX+1, z = curY }))
			//{
			//	curX++;
			//	grid.Add(key: new GridData { x = curX, z = curY }, tile);
			//}
		}
	}

	private void Reset()
	{
		grid.Clear();
		curX = 0;
		curY = 0;
	}
}
[System.Serializable]
public struct GridData
{
	public int x;
	public int z;
}


[System.Serializable]
public class TileData
{
	public TileType type;
	public GameObject prefab;
}
