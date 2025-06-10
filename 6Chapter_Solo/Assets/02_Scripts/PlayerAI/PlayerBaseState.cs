using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerBaseState : IState
{
	protected PlayerStateMachine stateMachine;
	protected float minDistance = 0f;
	public PlayerBaseState(PlayerStateMachine stateMachine)
	{
		this.stateMachine = stateMachine;
	}

	protected void StartAnimation(int animatorHash)
	{
		stateMachine.Player.Animator.SetBool(animatorHash, true);
	}

	protected void StopAnimation(int animatorHash)
	{
		stateMachine.Player.Animator.SetBool(animatorHash, false);
	}
	protected void Move()
	{
		Vector3 distance = stateMachine.Player.Target.position - stateMachine.Player.transform.position;
		Quaternion targetRotation = Quaternion.LookRotation(distance);
		//stateMachine.Player.transform.rotation = Quaternion.Slerp(stateMachine.Player.transform.rotation, targetRotation, Time.deltaTime);
		stateMachine.Player.transform.rotation = targetRotation;
		stateMachine.Player.transform.position += distance.normalized * stateMachine.Player.Data.StatDics[StatType.MoveSpeed] * Time.deltaTime;
	}

	protected void SearchTarget()
	{
		minDistance = float.MaxValue;
		foreach (var target in StateMachineManager.Instance.Enemies)
		{
			if (target.gameObject.activeSelf == false) continue;
			if (target.Target == null) continue;
			float distance = Vector3.Distance(stateMachine.Player.transform.position, target.transform.position);
			if (distance < minDistance)
			{
				minDistance = distance;
				stateMachine.Player.Target = target.transform;
			}
		}
		//stateMachine.Player.Target
	}

	protected float GetNormalizedTime(Animator animator, string tag)
	{
		AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
		//AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);
		//Debug.Log("버그 타임");

		//전환되고 있지 않을 때 현재 애니메이션이 tag라면
		if (!animator.IsInTransition(0) && currentInfo.IsTag(tag))
		{
			return currentInfo.normalizedTime;
		}
		//전환되고 있을 때 && 다음 애니메이션이 tag
		//else if (animator.IsInTransition(0)  && nextInfo.IsTag(tag))
		//{
		//	return nextInfo.normalizedTime;
		//}
		else
		{
			return 0f;
		}
	}


	public virtual void Enter()
	{
		
	}

	public virtual void Exit()
	{
		
	}


	public virtual void Update()
	{
	}
	public virtual void PhysicsUpdate()
	{
		
	}
}
