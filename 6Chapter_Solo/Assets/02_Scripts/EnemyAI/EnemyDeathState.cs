using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
	public EnemyDeathState(EnemyStateMachine stateMachine) : base(stateMachine)
	{
	}

	public override void Enter() //Enable
	{
		base.Enter();
		StartAnimation(stateMachine.Enemy.AnimationData.DeathParameterHash);
	}

	public override void Exit() //Disable
	{
		base.Exit();
		StopAnimation(stateMachine.Enemy.AnimationData.DeathParameterHash);
	}
	public override void Update() // 변하는 조건 + 행동.
	{
		base.Update();
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
