using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFindTargetState : PlayerBaseState
{
	public PlayerFindTargetState(PlayerStateMachine stateMachine) : base(stateMachine)
	{
	}

	public override void Enter() //Enable
	{
		base.Enter();
		StartAnimation(stateMachine.Player.AnimationData.FindParameterHash);
	}

	public override void Exit() //Disable
	{
		base.Exit();
		StopAnimation(stateMachine.Player.AnimationData.FindParameterHash);
	}
	public override void Update() // 변하는 조건 + 행동.
	{
		base.Update();
		SearchTarget();
		if (stateMachine.Player.Target != null)
		{
			stateMachine.ChangeState(stateMachine.MoveState);
			return;
		}
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
