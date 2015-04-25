using UnityEngine;
using System.Collections;

public class BulletCollide : MonoBehaviour 
{

	public float Velocity = .5f; 
	public float SecToDest = 15f;
	private float startTime; 
	//public float damage;
	m9_Fire m9;
	public float currentDamage;

	// Use this for initialization
	void Start () 
	{
		startTime = Time.time;
		GameController gameController;
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		m9 = gameController.m9;
	}


	void OnTriggerEnter(Collider other)
	{
		currentDamage = m9.damage;
		Debug.Log (currentDamage);
		if (other.gameObject.tag == "environment") 
		{
			//needs to leave scorch marks	
		}

		if (other.gameObject.tag == "Enemy") 
		{
			other.gameObject.GetComponent<AlienSoldierBehaviour>().TakeDamage(m9.damage);
		}

		//no matter what the bullet hits it should be destroyed
		Destroy (this.gameObject);
	
	}// end OnTrigger Function
	

	// Update is called once per frame
	void Update () 
	{
		//move forward
		this.gameObject.transform.position += Velocity * this.gameObject.transform.forward;

		//if the bullet exists too long it must be destroyed 
		if (Time.time - startTime >= SecToDest) 
		{
			Destroy (this.gameObject); 
		}
	
	}// end void update

	void OnCollisionEnter(Collision other)
	{
		Destroy (this.gameObject);
	}

}// end public Class BulletCollide
