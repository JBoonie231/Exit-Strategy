using UnityEngine;
using System.Collections;

public class LevelChange : MonoBehaviour {
	//This script to for buttons to call loadLevel functions
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void loadLevel1(){
		Application.LoadLevel ("Level 1");
	}
	public void loadLevel2(){
		Application.LoadLevel ("Level 2");
	}
	public void loadTitle(){
		Application.LoadLevel ("Title");
	}

}
