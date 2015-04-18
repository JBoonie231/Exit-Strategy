using UnityEngine;
using System.Collections;

public class AlienSoldierBehaviour : MonoBehaviour 
{
	public GameObject target;
	NavMeshAgent agent;

	GameObject player;

	public GameObject weapon;
	float health;

	enum TopState {Idle, Engage, Flee, Die};
	enum IdleState {Standing, Walking, Talking};
	enum EngageState {Waiting, Move, Shooting, Cover, Moving};


	TopState topState;
	IdleState idleState;
	EngageState engageState;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");

		topState = TopState.Engage;
		engageState = EngageState.Moving;
		agent = GetComponentInParent<NavMeshAgent>();
		agent.SetDestination(target.transform.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (topState)
		{
			case TopState.Idle:
				switch (idleState)
				{
					case IdleState.Standing:
						break;
					
					case IdleState.Talking:
						break;

					case IdleState.Walking:
						break;
				}
				break;

			case TopState.Engage:
				switch (engageState)
				{
					case EngageState.Cover:
						if(!target.GetComponent<EnemyWaypointBehaviour>().cover)
						{
							//engageState = (int)Random.Range(EngageState.Cover, EngageState.Waiting);
						}
						else
						{
							// Get into cover position and wait a certain amount of time
							//engageState = (int)Random.Range(EngageState.Cover, EngageState.Waiting);
						}
				engageState = EngageState.Shooting;
						break;
					
					case EngageState.Move:
						if(target == null || target.GetComponent<EnemyWaypointBehaviour>().waypoints.Length == 0)
						{
							//engageState = (int)Random.Range(EngageState.Cover, EngageState.Waiting);
					engageState = EngageState.Shooting;
						}
						else
						{
							target = target.GetComponent<EnemyWaypointBehaviour>().waypoints[Random.Range(0, target.GetComponent<EnemyWaypointBehaviour>().waypoints.Length)];
							agent.SetDestination(target.transform.position);
							engageState = EngageState.Moving;
						}
						break;

					case EngageState.Moving:
						if(transform.position == target.transform.position)
						{
							int damping = 2;
							
							Vector3 lookPos = player.transform.position - transform.position;
							lookPos.y = 0;
							Quaternion rotation = Quaternion.LookRotation(lookPos);
							transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
							engageState = EngageState.Cover;
						}
						break;
					
					case EngageState.Shooting:
						// Shoot a volley towards the player
						//engageState = (int)Random.Range(EngageState.Cover, EngageState.Waiting);
				engageState = EngageState.Waiting;
						break;

					case EngageState.Waiting:
						// Wait a certain amount of time
				//engageState = EngageState[(int)Random.Range(0f, 3f)];
				engageState = EngageState.Move;
						break;
				}
				break;

			case TopState.Flee:
				break;

			case TopState.Die:
				GameObject.Destroy(gameObject);
				break;

			default:
				break;
		}
	}

	public void TakeDamage(float amount)
	{
		health -= amount;

		if(health <= 0)
		{
			health = 0;
			topState = TopState.Die;
		}
	}
}
