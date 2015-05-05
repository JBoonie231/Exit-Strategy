using UnityEngine;
using System.Collections;

public class LevelChange : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}

	public void loadLevel1(){
		Application.LoadLevel ("SciFi Level");
	}
	public void loadLevel2(){
		Application.LoadLevel ("SciFi");
	}
	public void loadTitle(){
		Application.LoadLevel ("Title");
	}

}
