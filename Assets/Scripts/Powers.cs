using UnityEngine;
using System.Collections;

public class Powers : MonoBehaviour {
	public float bulletTimeScale;
	public float duration;
	public float currentTimer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Bullet Time
		if (Input.GetButtonDown ("F")) {
			if (Time.timeScale == 1.0)
				Time.timeScale = bulletTimeScale;
			else
				Time.timeScale = 1.0;
			if (Time.timeScale == bulletTimeScale) {
				currentTimer += Time.deltaTime;
			}
			if (currentTimer > duration) {
				currentTimer = 0;
				Time.timeScale = 0;
			}
			//Shield
		} else if (Input.GetButtonDown ("E")) {

		}
		
	}
	
	
}
