using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{
	private bool isAttackDamage;
	public PlayerAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
	{
	}
	public override void Enter() //Enable
	{
		base.Enter();
		StartAnimation(stateMachine.Player.AnimationData.AttackParameterHash);
		stateMachine.Player.Weapon.Damage = stateMachine.Player.Data.StatDics[StatType.Attack];
		isAttackDamage = false;
		CameraManager.Instance.SubCamOn();
	}

	public override void Exit() //Disable
	{
		base.Exit();
		StopAnimation(stateMachine.Player.AnimationData.AttackParameterHash);
		CameraManager.Instance.SubCamOff();
	}
	public override void Update() // 변하는 조건 + 행동.
	{
		base.Update();
		SearchTarget();
		if (minDistance > stateMachine.Player.Data.StatDics[StatType.AttackRange])
		{
			stateMachine.ChangeState(stateMachine.MoveState);
			return;
		}

		float normalizeTime = GetNormalizedTime(stateMachine.Player.Animator, "Attack");
		Debug.Log(normalizeTime);
		if (normalizeTime < 1f)
		{
			if (normalizeTime < 0.9f && normalizeTime >= 0.3f && !isAttackDamage)
			{
				//웨폰 켜준다
				Debug.Log("켜짐");
				stateMachine.Player.Weapon.gameObject.SetActive(true);
				AudioManager.Instance.SFXSource_Attack.Play();
				isAttackDamage = true;
			}

			if ( normalizeTime >= 0.9f && isAttackDamage)
			{
				//웨폰 거준다
				Debug.Log("꺼짐");
				stateMachine.Player.Weapon.enabled = false;
				AudioManager.Instance.SFXSource_Attack.Stop();
				isAttackDamage = false;
			}

		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
