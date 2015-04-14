using UnityEngine;
using System.Collections;

public class BulletCollide : MonoBehaviour 
{

	public float Velocity = .5; 
	public float SecToDest = 15;
	private float startTime; 

	// Use this for initialization
	void Start () 
	{
		startTime = Time.time;
	}


	void OnTriggerEnter(Collider other)
	{
		//no matter what the bullet hits it should be destroyed
		Destroy (this.gameObject);

		if (other.gameObject.tag == "environment") 
		{
			//needs to leave scorch marks	
		}

		if (other.gameObject.tag == "enemy") 
		{
			//needs to hurt the enemy
		}
		
	
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

}// end public Class BulletCollide
