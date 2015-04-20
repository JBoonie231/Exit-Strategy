using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	bool primaryFire;
	float lookVertical;
	float lookHorizontal;

	RaycastHit hit;
	float range = 50f;

	// Use this for initialization
	void Start () 
	{
		primaryFire = false;
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
				Debug.Log("Boom. Headshot.");

				StartCoroutine(destroyEnemyObject(hit.collider.gameObject));
			}
		}
	}
	IEnumerator destroyEnemyObject(GameObject gameObject){
		Debug.Log ("Delaying object destruction");
		yield return new WaitForSeconds(.3f);
		Debug.Log ("Object Destroyed");
		Destroy(gameObject);
	}
	void TurnHead ()
	{
		transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(90f*lookVertical, 90f*lookHorizontal, 0f), 5f);
	}
}
