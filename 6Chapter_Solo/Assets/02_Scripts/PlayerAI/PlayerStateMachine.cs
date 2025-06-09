using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStateMachine : StateMachine
{
	//플레이어의 패턴:
		// 주변 둘러보기 : FindTarget
		// 찾으면 달려가기 : Move
		// 공격하기 : Attack
    public Player Player;

	//스테이트의 종류를 보유
	//public PlayerIdleState IdleState; //가만히 있는 모션이 필요가 없음.
	public PlayerFindTargetState FindTargetState;
	public PlayerMoveState MoveState;
	public PlayerAttackState AttackState;
	public PlayerDeathState DeathState;

	public PlayerStateMachine(Player player)
    {
        this.Player = player;
        //IdleState = new PlayerIdleState(this);
		FindTargetState = new PlayerFindTargetState(this);
		MoveState = new PlayerMoveState(this);
		AttackState = new PlayerAttackState(this);
		DeathState = new PlayerDeathState(this);
	}
}
