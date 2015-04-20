using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour 
{

	public float Velocity; 
	public float SecToDest;
	public float damage;

	float startTime; 

	
	// Use this for initialization
	void Start () 
	{
		startTime = Time.time;
	}
	
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "environment") 
		{
			//needs to leave scorch marks	
		}
		
		if (other.gameObject.tag == "Player") 
		{
			other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
		}
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
}
