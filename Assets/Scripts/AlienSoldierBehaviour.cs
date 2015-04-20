using UnityEngine;
using System.Collections;

public class AlienSoldierBehaviour : MonoBehaviour 
{
	public GameObject target;
	public GameObject weapon;
	public int numberOfShots;
	public float timeBetweenShots;
	public float health;

	NavMeshAgent agent;

	GameObject player;
	GameObject tempWaypoint;

	enum TopState {Idle, Engage, Flee, Die};
	enum IdleState {Standing, Walking, Talking};
	enum EngageState {Waiting, Move, Shooting, Cover, Moving};

	bool waiting;
	float waitTime;
	int shotsTaken;

	float waitCooldown = 3f;

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
		//agent.SetDestination(target.transform.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		FSM ();
	}

	// Finite State Machine for Alien Soldier Behaviour
	void FSM()
	{
		switch (topState)
		{
		case TopState.Idle:
			switch (idleState)
			{
			case IdleState.Standing:
				Standing ();
				break;
				
			case IdleState.Talking:
				Talking ();
				break;
				
			case IdleState.Walking:
				Walking ();
				break;
			}
			break;
			
		case TopState.Engage:
			switch (engageState)
			{
			case EngageState.Cover:
				Cover ();
				break;
				
			case EngageState.Move:
				Move ();
				break;
				
			case EngageState.Moving:
				Moving ();
				break;
				
			case EngageState.Shooting:
				Shooting ();
				break;
				
			case EngageState.Waiting:
				Waiting ();
				break;
			}
			break;
			
		case TopState.Flee:
			Flee ();
			break;
			
		case TopState.Die:
			Die ();
			break;
			
		default:
			break;
		}
	}

	// State Functions

	void Flee()
	{
		
	}

	void Die()
	{
		if(target != null)
			target.GetComponent<EnemyWaypointBehaviour>().occupied = false;
		GameObject.Destroy(gameObject);
	}
	
	void Standing()
	{
		
	}
	
	void Walking()
	{
		
	}
	
	void Talking()
	{
		
	}
	
	void Waiting()
	{
		if(!waiting)
		{
			waiting = true;
			waitTime = Time.time + waitCooldown;
		}

		LookAtPlayer();

		//StartCoroutine(Wait(3f));
		if(Time.time > waitTime)
		{
			waiting = false;
			engageState = (EngageState)Random.Range(0, (int)EngageState.Moving-1);
		}
	}
	
	void Move()
	{
		if(target == null || target.GetComponent<EnemyWaypointBehaviour>().waypoints.Length == 0)
		{
			engageState = (EngageState)Random.Range(0, (int)EngageState.Moving-1);
		}
		else
		{
			tempWaypoint = target.GetComponent<EnemyWaypointBehaviour>().waypoints[Random.Range(0, target.GetComponent<EnemyWaypointBehaviour>().waypoints.Length)];
			if(!tempWaypoint.GetComponent<EnemyWaypointBehaviour>().occupied)
			{
				tempWaypoint.GetComponent<EnemyWaypointBehaviour>().occupied = true;
				target.GetComponent<EnemyWaypointBehaviour>().occupied = false;

				target = tempWaypoint;
				agent.SetDestination(target.transform.position);
				engageState = EngageState.Moving;
			}
			else
			{
				engageState = (EngageState)Random.Range(0, (int)EngageState.Moving-1);
			}
		}
	}

	// Shoot a volley towards the player
	void Shooting()
	{
		LookAtPlayer();

		if(numberOfShots > shotsTaken)
		{
			if(!waiting)
			{
				waiting = true;
				waitTime = Time.time + timeBetweenShots;
			}

			if(Time.time > waitTime)
			{
				waiting = false;
				shotsTaken++;

				weapon.GetComponent<WeaponBehaviour>().Fire();
			}
		}
		else
		{
			shotsTaken = 0;
			engageState = (EngageState)Random.Range(0, (int)EngageState.Moving-1);
		}
	}

	void Cover()
	{
		LookAtPlayer();

		if(target.GetComponent<EnemyWaypointBehaviour>().cover)
		{
			// Get into cover position and wait a certain amount of time
			engageState = (EngageState)Random.Range(0, (int)EngageState.Moving-1);
		}
		else
		{
			engageState = (EngageState)Random.Range(0, (int)EngageState.Moving-1);
		}
	}

	void Moving()
	{
		if(agent.enabled)
		{
			if(!agent.pathPending && agent.remainingDistance == 0)
			{
				engageState = (EngageState)Random.Range(0, (int)EngageState.Moving-1);
			}
		}
		// Fix for the navmesh spawn error
		else
		{
			agent.enabled = true;
			agent.SetDestination(target.transform.position);
		}
	}

	void LookAtPlayer()
	{
		int damping = 2;
		
		//Vector3 lookPos = player.transform.position - GetComponentInParent<Transform>().position;
		Vector3 lookPos = player.transform.position - transform.parent.position;

		lookPos.y = 90;
		Quaternion rotation = Quaternion.LookRotation(lookPos);
		//GetComponentInParent<Transform>().rotation = Quaternion.Slerp(GetComponentInParent<Transform>().rotation, rotation, Time.deltaTime * damping);
		transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, rotation, Time.deltaTime * damping);
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

	//IEnumerator Wait(float sec)
	//{
		//waiting = true;
		//yield return new WaitForSeconds(sec);
		//engageState = (EngageState)Random.Range(0, (int)EngageState.Moving-1);
		//waiting = false;
	//}
}
