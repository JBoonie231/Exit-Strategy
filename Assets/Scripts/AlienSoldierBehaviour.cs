using UnityEngine;
using System.Collections;

public class AlienSoldierBehaviour : MonoBehaviour 
{
	public Transform target;
	NavMeshAgent agent;

	public GameObject weapon;
	float health;

	enum TopState {Idle, Engage, Flee, Die};
	enum IdleState {Standing, Walking, Talking};
	enum EngageState {Waiting, Moving, Shooting, Cover};


	TopState topState;
	IdleState idleState;
	EngageState engageState;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponentInParent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		agent.SetDestination(target.position);
		switch (topState)
		{
			case TopState.Idle:
				switch (idleState)
				{

				}
				break;

			case TopState.Engage:
				switch (engageState)
				{

				}
				break;

			case TopState.Flee:
				break;

			case TopState.Die:
				break;

			default:
				break;
		}
	}
}
