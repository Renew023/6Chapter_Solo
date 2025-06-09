using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] private Collider myCollider;

	[SerializeField] private float damage;
	public float Damage { set => damage = value; }

	public void OnTriggerEnter(Collider other)
	{
		Utility.Print($"공격했습니다. ");
		if (other == myCollider) return;

		if(other.TryGetComponent(out ITakeDamage user))
		{
			user.TakeDamage(damage);
		}

	}

	public void OnDrawGizmos()
	{
		if (myCollider == null) return;
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(myCollider.bounds.center, 0.5f);
	}
}
