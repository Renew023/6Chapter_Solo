using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipItemData", menuName = "ScriptableObjects/EquipItemData")]
public class EquipItemDataSO : InventoryItemDataSO
{
	public int level;
	public EquipType equipType;
	public List<StatData> statTypes;
	public ItemRarity itemRarity;
}
