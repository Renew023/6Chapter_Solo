using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private Button hpUpButton;
	[SerializeField] private TextMeshProUGUI curHpText;
	[SerializeField] private TextMeshProUGUI hpUpPriceText;
	[SerializeField] private int hpUpPrice = 10;
	[SerializeField] private int hpUpLevel = 0;
	[SerializeField] private int hpUpPriceUp = 5;
	[SerializeField] private float hpUpAmount = 10f;

	[SerializeField] private Button damageUpButton;
	[SerializeField] private TextMeshProUGUI curDamageText;
	[SerializeField] private TextMeshProUGUI damageUpPriceText;
	[SerializeField] private int damageUpPrice = 50;
	[SerializeField] private int damageUpLevel = 0;
	[SerializeField] private int damageUpPriceUp = 10;
	[SerializeField] private float damageUpAmount = 1f;

	[SerializeField] private Button speedUpButton;
	[SerializeField] private TextMeshProUGUI curSpeedText;
	[SerializeField] private TextMeshProUGUI speedUpPriceText;
	[SerializeField] private int speedUpPrice = 20;
	[SerializeField] private int speedUpLevel = 0;
	[SerializeField] private int speedUpPriceUp = 10;
	[SerializeField] private float speedUpAmount = 0.1f;

	[SerializeField] private Button closeButton;

	void Awake()
	{
		hpUpButton.onClick.AddListener(() => AddStat(StatType.Health));
		damageUpButton.onClick.AddListener(() => AddStat(StatType.Attack));
		speedUpButton.onClick.AddListener(() => AddStat(StatType.MoveSpeed));
		closeButton.onClick.AddListener(() => gameObject.SetActive(false));
	}

	public void UpdateUI()
	{
		var player = StateMachineManager.Instance.Player;
		hpUpPriceText.text = (hpUpPrice+hpUpLevel*hpUpPriceUp).ToString();
		curHpText.text = player.MaxHealth.ToString();

		damageUpPriceText.text = (damageUpPrice + damageUpLevel*damageUpPriceUp).ToString();
		curDamageText.text = player.Data.StatDics[StatType.Attack].ToString();

		speedUpPriceText.text = (speedUpPrice + speedUpLevel*speedUpPriceUp).ToString();
		curSpeedText.text = player.Data.StatDics[StatType.MoveSpeed].ToString();
	}

	private void AddStat(StatType statType)
	{
		var data = StateMachineManager.Instance.Player.Data;
		switch (statType)
		{
			case StatType.Health:
				if(data.StatDics[StatType.Gold] < hpUpPrice + hpUpLevel * hpUpPriceUp)
				{
					Debug.Log("Not enough gold for HP upgrade");
					return;
				}
				StateMachineManager.Instance.Player.Data.StatDics[StatType.Gold] -= (hpUpPrice + hpUpLevel*hpUpPriceUp);
				StateMachineManager.Instance.Player.MaxHealth += (int)hpUpAmount;
				hpUpLevel++;
				break;
			case StatType.Attack:
				if (data.StatDics[StatType.Gold] < damageUpPrice + damageUpLevel * damageUpPriceUp)
				{
					Debug.Log("Not enough gold for Damage upgrade");
					return;
				}
				StateMachineManager.Instance.Player.Data.StatDics[StatType.Gold] -= (damageUpPrice + damageUpLevel * damageUpPriceUp);
				StateMachineManager.Instance.Player.Data.StatDics[StatType.Attack] += damageUpAmount;
				damageUpLevel++;
				break;
			case StatType.MoveSpeed:
				if (data.StatDics[StatType.Gold] < speedUpPrice + speedUpLevel * speedUpPriceUp)
				{
					Debug.Log("Not enough gold for Speed upgrade");
					return;
				}
				StateMachineManager.Instance.Player.Data.StatDics[StatType.Gold] -= (speedUpPrice + speedUpLevel * speedUpPriceUp);
				StateMachineManager.Instance.Player.Data.StatDics[StatType.MoveSpeed] += speedUpAmount;
				speedUpLevel++;
				break;
			default:
				Debug.LogError("Unknown stat type");
				break;
		}
		UpdateUI();
		Inventory.Instance.playerStatPanel.GoldUIReload();
	}
}
