using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemData", menuName = "ScriptableObjects/InventoryItemData")]
public class InventoryItemDataSO : ItemDataSO
{
	public int itemIndex;
	public string itemName;
	[TextArea] public string description;
}
