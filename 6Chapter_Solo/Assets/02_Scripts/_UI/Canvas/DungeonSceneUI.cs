using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DungeonSceneUI : MonoBehaviour
{
	[SerializeField] private Player player;

	[SerializeField] private GameObject inventoryPanel;
	[SerializeField] private Button inventoryOpenButton;
	[SerializeField] private Button inventoryCloseButton;
	[SerializeField] private GameObject ShopPanel;
	[SerializeField] private Button shopOpenButton;
	//정보
	[SerializeField] private GameObject itemDataViewer;
	[SerializeField] private TextMeshProUGUI itemDataText;
	[SerializeField] private Button itemEquipButton;

	public void Awake()
	{
		inventoryOpenButton.onClick.AddListener(() => inventoryPanel.SetActive(true));
		inventoryCloseButton.onClick.AddListener(() => inventoryPanel.SetActive(false));

		shopOpenButton.onClick.AddListener(() => ShopPanel.SetActive(true));
	}
	public void Start()
	{
		itemEquipButton.onClick.AddListener(() => Equip(Inventory.Instance.CheckIndex));
	}
	public void Equip(int index)
	{
		var itemData = Inventory.Instance.ItemDatas[index];
		EquipItemDataSO equipItem = itemData as EquipItemDataSO;
		foreach (var item in player.itemEquip)
		{

			if (item.equipType == equipItem.equipType)
			{
				//해당 장비를 이미 착용 중이라면,
				if (item.isEquip)
				{
					Debug.Log("해제됨");
					//그 부위에 장착을 해제하고
					item.isEquip = false;
					//능력치를 빼낸다.
					UnEquip(equipItem);
				}
				else
				{
					Debug.Log("장착됨");
					//그 부위에 장착을 하고
					item.isEquip = true;
					//능력치를 더한다.
					Equip(equipItem);
				}
				Inventory.Instance.ItemSlots[index].EquipMark.SetActive(item.isEquip);
			}
		}
		
		
		{
			//EquipMark를 달아준다.
		}
	}

	public void Equip(EquipItemDataSO equipItem)
	{
		foreach (var stat in equipItem.statTypes)
		{
			player.Data.StatDics[stat.StatType] += stat.BaseValue;
		}
	}

	public void UnEquip(EquipItemDataSO equipItem)
	{
		foreach (var stat in equipItem.statTypes)
		{
			player.Data.StatDics[stat.StatType] -= stat.BaseValue;
		}
	}

    public void DataView(int index)
	{
		itemDataViewer.SetActive(true);
		Inventory.Instance.CheckIndex = index;
		//itemDataViewer.transform.position = new Vector3(pos.x, pos.y, pos.z+1.0f);
		var itemData = Inventory.Instance.ItemDatas[index];
		switch(itemData.itemType)
		{
			case ItemType.Equip:
				EquipItemDataSO equipItem = itemData as EquipItemDataSO;
				itemDataText.text = $"아이템 이름: {equipItem.itemName}\n" +
								$"아이템 타입: {equipItem.itemType}\n" +
								$"아이템 등급: {equipItem.itemRarity}\n" +
								$"아이템 설명: {equipItem.description}\n";
				itemDataText.text += $"아이템 착용 타입: {equipItem.equipType}\n";
				itemEquipButton.gameObject.SetActive(true);
				break;
			case ItemType.Resource:
				ResourceItemDataSO ResourceItem = itemData as ResourceItemDataSO;
				itemDataText.text = $"아이템 이름: {ResourceItem.itemName}\n" +
								$"아이템 타입: {ResourceItem.itemType}\n" +
								$"아이템 설명: {ResourceItem.description}\n";
				break;
		}
	}

	public void OnDisable()
	{
		itemEquipButton.gameObject.SetActive(false);
		itemDataText.text = "";
	}
}
