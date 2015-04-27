using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	public Transform background;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime);
	}

	void OnGUI(){
		GUI.color = Color.gray;
		if (GUI.Button (new Rect (600, 400, 100, 50), "Try Again")) 
		{
			Application.LoadLevel ("Title");
		}
	}
}
