using UnityEngine;
using System.Collections;

public class Rotate_Gun : MonoBehaviour {

	
	// Update is called once per frame
	void Update () 
	{
		Vector3 mousePos = Input.mousePosition;
		transform.LookAt(Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10.0f)));
	}

}