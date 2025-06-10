using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private int slotIndex; 
    [SerializeField] private TextMeshProUGUI itemValue;
    [SerializeField] private Button showData;
    [SerializeField] private GameObject equipMark;
    public GameObject EquipMark { get => equipMark; }

    void Awake()
    {
        showData.OnClick(() => Inventory.Instance.dungeonSceneUI.DataView(slotIndex));
    }

    public void Init(int index)
    {
        slotIndex = index;
    }

    public void UpdateUI(int value)
    {
        itemValue.text = value.ToString();
    }
}
