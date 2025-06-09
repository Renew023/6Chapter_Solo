using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{

	private bool isAttackDamage;
	public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine)
	{
	}
	public override void Enter() //Enable
	{
		base.Enter();
		StartAnimation(stateMachine.Enemy.AnimationData.AttackParameterHash);
		stateMachine.Enemy.Weapon.Damage = stateMachine.Enemy.Data.StatDics[StatType.Attack];
		isAttackDamage = false;
	}

	public override void Exit() //Disable
	{
		base.Exit();
		StopAnimation(stateMachine.Enemy.AnimationData.AttackParameterHash);
	}
	public override void Update() // 변하는 조건 + 행동.
	{
		base.Update();
		SearchTarget();

		if (minDistance > stateMachine.Enemy.Data.StatDics[StatType.AttackRange])
		{
			stateMachine.ChangeState(stateMachine.MoveState);
			return;
		}

		float normalizeTime = GetNormalizedTime(stateMachine.Enemy.Animator, "Attack");

		if (normalizeTime < 1f)
		{
			if (normalizeTime < 0.9f && normalizeTime >= 0.1f && !isAttackDamage)
			{
				//웨폰 켜준다
				Debug.Log("켜짐");
				stateMachine.Enemy.Weapon.gameObject.SetActive(true);
				isAttackDamage = true;
			}

			if (normalizeTime >= 0.9f && isAttackDamage)
			{
				//웨폰 거준다
				Debug.Log("꺼짐");
				stateMachine.Enemy.Weapon.enabled = false;
				isAttackDamage = false;
			}

		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}

}
