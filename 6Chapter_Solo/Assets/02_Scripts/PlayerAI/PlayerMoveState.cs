using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
	public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine)
	{
	}
	public override void Enter() //Enable
	{
		base.Enter();
		StartAnimation(stateMachine.Player.AnimationData.MoveParameterHash);
		AudioManager.Instance.SFXSource_Running.Play();
		CameraManager.Instance.ChangeCam(Cam.main);
	}

	public override void Exit() //Disable
	{
		base.Exit();
		StopAnimation(stateMachine.Player.AnimationData.MoveParameterHash);
		AudioManager.Instance.SFXSource_Running.Stop();
	}
	public override void Update() // 변하는 조건 + 행동.
	{
		base.Update();
		SearchTarget();
		Move();

		if(minDistance < stateMachine.Player.Data.StatDics[StatType.AttackRange])
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
