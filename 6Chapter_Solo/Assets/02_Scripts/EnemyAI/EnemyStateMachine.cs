using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
	//몬스터 패턴 :
	//플레이어 쫓기 : Move
	//공격하기 : Attack
	// 죽기 : Death
	public Enemy Enemy;

	public EnemyMoveState MoveState;
	public EnemyAttackState AttackState;
	public EnemyDeathState DeathState;

	public EnemyStateMachine(Enemy enemy)
	{
		this.Enemy = enemy;

		MoveState = new EnemyMoveState(this);
		AttackState = new EnemyAttackState(this);
		DeathState = new EnemyDeathState(this);
	}
}
