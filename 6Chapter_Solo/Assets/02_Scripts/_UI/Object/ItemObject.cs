using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemObject : MonoBehaviour
{
    [SerializeField] private ItemDataSO itemData;
	[SerializeField] private Transform target;
	[SerializeField] private GameObject itemObjectPrefab;

	public ItemDataSO ItemData { get => itemData; }

	void OnEnable()
	{
		target = FindObjectOfType<Player>().transform;
		StartCoroutine(TargetItem());
		itemObjectPrefab = transform.GetChild(0).gameObject;
	}

	void OnDisable()
	{
		StopCoroutine(TargetItem());
	}

	public void OnTriggerEnter(Collider other)
	{
		Utility.Print("아이템 획득");
		if (other.TryGetComponent<Player>(out Player player))
		{
			InventoryItemDataSO inventoryItem = itemData as InventoryItemDataSO;
			if (inventoryItem != null)
			{
				int index = inventoryItem.itemIndex;

				if (Inventory.Instance.ItemDatas.ContainsKey(index))
				{
					Utility.Print($"이미 {inventoryItem.itemName} 아이템이 있습니다.");
					Inventory.Instance.ItemDatas[index].value += inventoryItem.value;
					Inventory.Instance.ItemSlots[index].UpdateUI(Inventory.Instance.ItemDatas[index].value); ;
				}
				else
				{
					Inventory.Instance.ItemDatas.Add(index, Instantiate(inventoryItem));
					Inventory.Instance.ItemSlots.Add(index, Instantiate(Inventory.Instance.ItemSlotPrefab, Inventory.Instance.InventoryPanel));
					Inventory.Instance.ItemSlots[index].Init(index);
					Image image = Inventory.Instance.ItemSlots[index].transform.GetChild(0).GetComponent<Image>();
					image.sprite = itemObjectPrefab.GetComponent<SpriteRenderer>().sprite;
					image.color = itemObjectPrefab.GetComponent<SpriteRenderer>().color;
					//Instantiate(itemObjectPrefab, Inventory.Instance.ItemSlots[inventoryItem.itemIndex].transform);
				}
			}
			else
			{

			}
			if (itemData.itemType == ItemType.Gold)
			{
				player.Data.StatDics[StatType.Gold] += itemData.value;
				Inventory.Instance.playerStatPanel.GoldUIReload();
			}

			if (itemData.itemType == ItemType.Exp)
			{
				float exp = player.Data.StatDics[StatType.Exp];
				float level = player.Data.StatDics[StatType.Level];
				exp += itemData.value;

				if(exp >= level * 5)
				{
					exp -= level * 5;
					level += 1;
					player.Data.StatDics[StatType.Level]++;
					player.MaxHealth += 10;
					player.Data.StatDics[StatType.Attack] += 1;
					//TODO : UI 분리 필요
					Inventory.Instance.playerStatPanel.HpUIReload();
				}

				player.Data.StatDics[StatType.Exp] = exp;
				player.Data.StatDics[StatType.Level] = level;
				//TODO : UI 분리 필요
				Inventory.Instance.playerStatPanel.LevelUIReload();
				Inventory.Instance.shopPanel.UpdateUI();
			}
			//

			//확정
			Destroy(gameObject);
		}
	}

	IEnumerator TargetItem()
	{
		float timeForce = 0f;
		float itemForceSpeed = 10f;
		yield return new WaitForSeconds(1.0f); // Wait for the player to be ready
		while (true)
		{
			transform.position += (target.position - transform.position).normalized * (Time.deltaTime+timeForce);
			timeForce += Time.deltaTime * Time.deltaTime * itemForceSpeed;
			yield return null;
		}
	}
}
