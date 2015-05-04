using UnityEngine;
using System.Collections;

public class WeaponBehaviour : MonoBehaviour 
{
	public bool checkIfLevel2;
	public GameObject Projectile;
	GameObject target;

	void Awake ()
	{
		if(checkIfLevel2 == true)
			target = GameObject.FindGameObjectWithTag("Target");
		else
			target = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
	{
		Vector3 mousePos = Input.mousePosition;
		transform.LookAt(target.transform.position);
	}
	
	public void Fire()
	{
		GameObject clone;
		clone = Instantiate (Projectile, transform.position, transform.rotation) as GameObject;
	}
}
