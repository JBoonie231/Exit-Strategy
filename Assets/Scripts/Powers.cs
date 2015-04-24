using UnityEngine;
using System.Collections;

public class Powers : MonoBehaviour {
	public float effectiveness = 0.1f;
	public float duration = 5.0f;
	public float currentTimer;
	public float cooldown = 20f;
	public bool bulletEnable = true;
	public float timeScale;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Bullet Time
		if (Input.GetKeyDown (KeyCode.F) && bulletEnable == true) {
			bulletEnable = false;
			StartCoroutine("startBulletTime");
		}
			if (Time.timeScale == convert(effectiveness)) {
				currentTimer += Time.deltaTime;
			}
			if (currentTimer > duration) {
				currentTimer = 0;
				Time.timeScale = 1f;
			}
			//Shield
		 
		if (Input.GetKeyDown (KeyCode.E)) {
				Debug.Log ("SHIELD ACTIVATED");
			}
		
	}
	IEnumerator startBulletTime(){
		if (Time.timeScale == 1.0f) {
			Time.timeScale = convert(effectiveness);
		} else {
			Time.timeScale = 1.0f;
		}
		yield return new WaitForSeconds(cooldown);
		bulletEnable = true;
	}
	float convert(float current){
		timeScale = 1 - (current);
		return timeScale;
	}
	
}
