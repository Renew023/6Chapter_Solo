using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyBaseState
{
	public EnemyMoveState(EnemyStateMachine stateMachine) : base(stateMachine)
	{
	}

	public override void Enter() //Enable
	{
		base.Enter();
		StartAnimation(stateMachine.Enemy.AnimationData.MoveParameterHash);
	}

	public override void Exit() //Disable
	{
		base.Exit();
		StopAnimation(stateMachine.Enemy.AnimationData.MoveParameterHash);
	}
	public override void Update() // 변하는 조건 + 행동.
	{
		base.Update();
		Move();
		SearchTarget();

		if (minDistance < stateMachine.Enemy.Data.StatDics[StatType.AttackRange])
		{
			stateMachine.ChangeState(stateMachine.AttackState);
			return;
		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
