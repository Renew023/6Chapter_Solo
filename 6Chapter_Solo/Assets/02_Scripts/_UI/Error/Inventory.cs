using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
	public ItemSlot ItemSlotPrefab;

	public Dictionary<int, InventoryItemDataSO> ItemDatas = new Dictionary<int, InventoryItemDataSO>();
	public int CheckIndex = 0;
	//UI
	public Dictionary<int, ItemSlot> ItemSlots = new Dictionary<int, ItemSlot>();
	public DungeonSceneUI dungeonSceneUI;
	public PlayerStatPanel playerStatPanel;
	public ShopPanel shopPanel;
	public Transform InventoryPanel;
    private ItemType viewInventoryType = ItemType.Equip;

	void OnEnable()
	{
		ViewInventory();	
	}

	private void ViewInventory()
	{
		foreach (var item in ItemDatas)
		{
			ItemSlots[item.Key].gameObject.SetActive(false);
		}

		switch (viewInventoryType)
		{
			case ItemType.Equip:
				foreach (var item in ItemDatas)
				{
					if (item.Value.itemType == ItemType.Equip)
					{
						ItemSlots[item.Key].gameObject.SetActive(true);
					}
				}
				break;
			case ItemType.Resource:
				foreach (var item in ItemDatas)
				{
					if (item.Value.itemType == ItemType.Resource)
					{
						ItemSlots[item.Key].gameObject.SetActive(true);
					}
				}
				break;
		}
	}
}
