using UnityEngine;
using System.Collections;

public class AlienQueenBehaviour : MonoBehaviour 
{

	public GameObject weapon;
	public int numberOfShots;
	public float timeBetweenShots;
	public float health;
	
	Animator anim;

	GameObject player;
	GameController gameController;
	
	enum TopState {Idle, Attack, Die};

	bool waiting;
	float waitTime;
	int shotsTaken;
	
	float waitCooldown = 3f;
	
	TopState topState;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		anim = GetComponentInChildren<Animator>();
		
		topState = TopState.Idle;
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
			Idle();
			break;
			
		case TopState.Attack:
			Attack();
			break;
			
		case TopState.Die:
			Die ();
			break;
			
		default:
			break;
		}
	}
	
	// State Functions
	
	void Idle()
	{
		anim.SetBool("Attack",false);
		Waiting ();
	}
	
	void Die()
	{
		StartCoroutine(WaitToDie(2f));
	}
	
	// Shoot a volley towards the player
	void Attack()
	{
		anim.SetBool("Attack",true);

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
			topState = (TopState)Random.Range(0, (int)TopState.Die);
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
	
	IEnumerator WaitToDie(float sec)
	{
		yield return new WaitForSeconds(sec);
		gameController.kills++;
		gameController.tempKillCount++;
		GameObject.Destroy(transform.gameObject);
	}

	void Waiting()
	{
		if(!waiting)
		{
			waiting = true;
			waitTime = Time.time + waitCooldown;
		}

		//StartCoroutine(Wait(3f));
		if(Time.time > waitTime)
		{
			waiting = false;
			topState = (TopState)Random.Range(0, (int)TopState.Die);
		}
	}

}
