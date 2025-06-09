using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : IState
{
	protected EnemyStateMachine stateMachine;
	protected float minDistance = float.MaxValue;
	public EnemyBaseState(EnemyStateMachine stateMachine)
	{
		this.stateMachine = stateMachine;
	}
	protected void StartAnimation(int animatorHash)
	{
		stateMachine.Enemy.Animator.SetBool(animatorHash, true);
	}

	protected void StopAnimation(int animatorHash)
	{
		stateMachine.Enemy.Animator.SetBool(animatorHash, false);
	}

	protected void Move()
	{
		Vector3 distance = stateMachine.Enemy.Target.position - stateMachine.Enemy.transform.position;
		Quaternion targetRotation = Quaternion.LookRotation(distance);
		//stateMachine.Player.transform.rotation = Quaternion.Slerp(stateMachine.Player.transform.rotation, targetRotation, Time.deltaTime);
		stateMachine.Enemy.transform.rotation = targetRotation;
		stateMachine.Enemy.transform.position += distance.normalized * stateMachine.Enemy.Data.StatDics[StatType.MoveSpeed] * Time.deltaTime;
	}

	protected void SearchTarget()
	{
		if (StateMachineManager.Instance.Player.Target == null)
		{
			minDistance = float.MaxValue;
			return;
		}
		
		minDistance = Vector3.Distance(stateMachine.Enemy.transform.position, stateMachine.Enemy.Target.position);
	}

	protected float GetNormalizedTime(Animator animator, string tag)
	{
		AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);
		AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0);
		//Debug.Log("버그 타임");

		//전환되고 있을 때 && 다음 애니메이션이 tag
		if (animator.IsInTransition(0))
		{
			return nextInfo.normalizedTime;
		}
		//전환되고 있지 않을 때 현재 애니메이션이 tag라면
		else if (!animator.IsInTransition(0))
		{
			return currentInfo.normalizedTime;
		}
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

	public virtual void PhysicsUpdate()
	{
		
	}

	public virtual void Update()
	{

	}
}
