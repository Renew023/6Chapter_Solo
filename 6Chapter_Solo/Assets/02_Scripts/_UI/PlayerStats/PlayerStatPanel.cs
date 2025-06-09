using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatPanel : MonoBehaviour
{
	[Header("Data")]
	[SerializeField] private Player player;

	[Header("UI")]
	[SerializeField] private TextMeshProUGUI hpText;
	[SerializeField] private Image hpBar;
	[SerializeField] private TextMeshProUGUI levelText;
	[SerializeField] private TextMeshProUGUI expText;
	[SerializeField] private Image expBar;
	[SerializeField] private TextMeshProUGUI goldText;

	public void HpUIReload()
	{
		float hp = player.Data.StatDics[StatType.Health];
		float maxHp = player.MaxData.StatDics[StatType.Health];
		hpText.text = hp.ToString() + "/" + maxHp.ToString();
		hpBar.fillAmount = hp/maxHp;
	}

	public void LevelUIReload()
	{
		int level = (int)player.Data.StatDics[StatType.Level];
		int exp = (int)player.Data.StatDics[StatType.Exp];
		int expSize = 5;
		levelText.text = level.ToString();
		expText.text =exp.ToString() +" / "+ (level*expSize).ToString();
		expBar.fillAmount = exp / (float)(level * expSize);
	}

	public void GoldUIReload()
	{
		goldText.text = player.Data.StatDics[StatType.Gold].ToString();
	}
}
