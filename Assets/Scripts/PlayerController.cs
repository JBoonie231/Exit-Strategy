using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float health;
	public float maxHealth;
	public int lives;
	bool primaryFire;
	float lookVertical;
	float lookHorizontal;
	public bool shieldEnable = true;
	public bool shieldOn = false;
	public float shieldDamage = 1f;
	public int shieldDuration = 0;
	RaycastHit hit;
	float range = 50f;

	//for switching weapons
	public GameObject m9;
	public GameObject Repeater; 


	// Use this for initialization
	void Start () 
	{
		primaryFire = false;
		health = maxHealth;
		m9.gameObject.SetActive (true); //to start with the m9 pistol
		Repeater.gameObject.SetActive (false); //can later switch to repeater
	}
	
	// Update is called once per frame
	void Update () 
	{


		lookVertical = -Input.GetAxis("Vertical");
		lookHorizontal = Input.GetAxis("Horizontal");
		primaryFire = Input.GetButtonDown("Fire1");

		TurnHead();

		if (primaryFire)
		{
			PrimaryFire();
		}
		//Enable repeater
		if (Input.GetKeyDown ("2")) 
		{
			if (m9.gameObject == true) 
			{
				m9.gameObject.SetActive (false);
				Repeater.gameObject.SetActive (true);
			}
		}
		//enable pistol
		if (Input.GetKeyDown ("1")) {
			
			if (Repeater.gameObject == true)
			{
				Repeater.gameObject.SetActive (false);
				m9.gameObject.SetActive (true);
			}
		}

	}
	//Fire weapon
	void PrimaryFire ()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, range))
		{
			if (hit.collider.gameObject.tag == "Enemy")
			{
				//Debug.Log("Boom. Headshot.");

				//StartCoroutine(destroyEnemyObject(hit.collider.gameObject));
			}
		}
	}
	//Destroy enemy after .3f seconds
	IEnumerator destroyEnemyObject(GameObject gameObject){
		//Debug.Log ("Delaying object destruction");
		yield return new WaitForSeconds(.3f);
		//Debug.Log ("Object Destroyed");
		Destroy(gameObject);
	}
	//Turns camera/head based on ASDF input
	void TurnHead ()
	{
		transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(90f*lookVertical, 90f*lookHorizontal, 0f), 5f);
	}

	//Decrement health of player when called. If the shield is enabled
	//The damage is reduced, if the player runs out of health, decrement a life.
	//If the player has no more lives load game over screen
	public void TakeDamage(float amount)
	{
		if (shieldOn == false) {
			health -= amount;
		} else {
			health -= shieldDamage;
		}
		if(health <= 0)
		{
			health = maxHealth;
			lives--;
			// Game Over
			if(lives ==0){
				Application.LoadLevel("GameOver");
			}
			Debug.Log("Player Death");
		}
	}
	
}
