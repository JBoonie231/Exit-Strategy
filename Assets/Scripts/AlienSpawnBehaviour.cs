using UnityEngine;
using System.Collections;

public class AlienSpawnBehaviour : MonoBehaviour 
{
	public float health;
	public float jumpDistance;
	public float attackDistance;
	public float damage;
	public float speed;
	
	Animator anim;

	GameObject player;
	GameObject target;
	GameController gameController;
	
	enum TopState {Running, Jumping, Attack, Die};

	float waitTime;
	
	TopState topState;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		target = GameObject.FindGameObjectWithTag("Player Face");
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		anim = GetComponentInChildren<Animator>();
		
		topState = TopState.Running;
		anim.SetTrigger("Running");
	}
	
	// Update is called once per frame
	void Update () 
	{
		FSM ();
	}
	
	// Finite State Machine for Alien Soldier Behaviour
	void FSM()
	{
		LookAtPlayer();

		switch (topState)
		{
		case TopState.Running:
			Running();
			break;
			
		case TopState.Jumping:
			Jumping();
			break;
			
		case TopState.Attack:
			Attack();
			break;
			
		case TopState.Die:
			Die();
			break;
			
		default:
			break;
		}
	}
	
	// State Functions
	
	void Running()
	{
		if(Vector3.Distance(transform.position, player.transform.position) < jumpDistance)
		{
			topState = TopState.Jumping;
			anim.SetTrigger("Jumping");
		}
		else
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}
	}
	
	void Jumping()
	{
		if(Vector3.Distance(transform.position, target.transform.position) < attackDistance)
		{
			topState = TopState.Attack;
			anim.SetTrigger("Attack");
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
		}
	}
	
	void Attack()
	{
		topState = TopState.Die;
		waitTime = 2f;
		player.GetComponent<PlayerController>().TakeDamage(damage);
	}

	void Die()
	{
		anim.SetTrigger("Death");
		
		StartCoroutine(WaitToDie(waitTime));
	}

	void LookAtPlayer()
	{
		int damping = 2;
		
		Vector3 lookPos = player.transform.position - transform.position;
		
		lookPos.y = 0;
		Quaternion rotation = Quaternion.LookRotation(lookPos);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}
	
	public void TakeDamage(float amount)
	{
		health -= amount;
		
		if(health <= 0)
		{
			health = 0;
			topState = TopState.Die;
			waitTime = 1f;
		}
	}
	
	IEnumerator WaitToDie(float sec)
	{
		yield return new WaitForSeconds(sec);
		gameController.kills++;
		gameController.tempKillCount++;
		GameObject.Destroy(transform.gameObject);
	}
}
