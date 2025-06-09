using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachineManager : Singleton<StateMachineManager>
{
    [SerializeField] public Player Player;
	[SerializeField] public List<Enemy> Enemies = new List<Enemy>();

	void Update()
	{
		//업데이트 관리
		Player?.StateMachine.Update();
		foreach (var enemy in Enemies)
		{
			enemy.StateMachine.Update();
		}
	}

	void FixedUpdate()
	{
		//물리 업데이트 관리
		Player?.StateMachine.PhysicsUpdate();
		foreach (var enemy in Enemies)
		{
			enemy.StateMachine.PhysicsUpdate();
		}
	}
}
