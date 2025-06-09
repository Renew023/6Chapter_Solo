using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
	//DO : 멈춘 상태를 의미
	public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
	{
	}

	public override void Enter()
	{
		base.Enter();
		//StartAnimation
	}

	public override void Exit()
	{
		base.Exit();
		//StopAnimation
	}
	public override void Update()
	{
		base.Update();
	}
	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
