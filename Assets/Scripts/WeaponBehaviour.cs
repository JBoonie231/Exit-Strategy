using UnityEngine;
using System.Collections;

public class WeaponBehaviour : MonoBehaviour 
{

	public GameObject Projectile;
	GameObject target;

	void Awake ()
	{
		target = GameObject.FindGameObjectWithTag("Target");
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
