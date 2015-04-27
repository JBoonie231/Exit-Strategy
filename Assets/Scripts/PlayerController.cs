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

	// Use this for initialization
	void Start () 
	{
		primaryFire = false;
		health = maxHealth;

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

	}

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
	IEnumerator destroyEnemyObject(GameObject gameObject){
		//Debug.Log ("Delaying object destruction");
		yield return new WaitForSeconds(.3f);
		//Debug.Log ("Object Destroyed");
		Destroy(gameObject);
	}
	void TurnHead ()
	{
		transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(90f*lookVertical, 90f*lookHorizontal, 0f), 5f);
	}

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
