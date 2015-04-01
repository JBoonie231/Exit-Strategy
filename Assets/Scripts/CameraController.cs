using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public bool focus;
	public GameObject target;

	// Use this for initialization
	void Start () 
	{
		focus = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Focus ();
	}

	public void Focus()
	{
		if (focus)
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), .01f);
		else
			transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.identity, .01f);
	}
}
