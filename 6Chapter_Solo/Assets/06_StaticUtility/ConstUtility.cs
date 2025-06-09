using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AnimationData
{
	[SerializeField] private string idleParamenterName = "Idle";
	[SerializeField] private string findParameterName = "Find";
	[SerializeField] private string moveParameterName = "Move";
	[SerializeField] private string attackParameterName = "Attack";
	[SerializeField] private string deathParameterName ="Death";


	public int IdleParameterHash { get; private set; }
	public int FindParameterHash { get; private set; }
	public int MoveParameterHash { get; private set; }
	public int AttackParameterHash { get; private set; }
	public int DeathParameterHash { get; private set; }

	public void Initialize()
	{
		IdleParameterHash = Animator.StringToHash(idleParamenterName);
		FindParameterHash = Animator.StringToHash(findParameterName);
		MoveParameterHash = Animator.StringToHash(moveParameterName);
		AttackParameterHash = Animator.StringToHash(attackParameterName);
		DeathParameterHash = Animator.StringToHash(deathParameterName);
	}

}
