using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	public Transform background;
	// Use this for initialization
	void Start () {
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime);
	}

	void OnGUI(){
		GUI.color = Color.white;
		if (GUI.Button (new Rect (910, 600, 100, 50), "Try Again")) 
		{
			Application.LoadLevel ("Title");
		}
	}
}
