using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
	public PlayerDeathState(PlayerStateMachine stateMachine) : base(stateMachine)
	{
	}

	public override void Enter() //Enable
	{
		base.Enter();
		StartAnimation(stateMachine.Player.AnimationData.DeathParameterHash);
		CameraManager.Instance.ChangeCam(Cam.death);
	}

	public override void Exit() //Disable
	{
		base.Exit();
		StopAnimation(stateMachine.Player.AnimationData.DeathParameterHash);
	}
	public override void Update() // 변하는 조건 + 행동.
	{
		base.Update();
		Debug.Log("너는 죽어있다.");
	}

	public override void PhysicsUpdate()
	{
		base.PhysicsUpdate();
	}
}
