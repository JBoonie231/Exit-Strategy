using UnityEngine;
using System.Collections;

public class Powers : MonoBehaviour {
	public float effectiveness = 0.1f;
	public float duration = 5.0f;
	public float bulletTimer;
	public float shieldTimer;
	public float cooldown = 20f;
	public bool bulletEnable = true;
	public float timeScale;
	public GameController gameController;
	public PlayerController player;
	// Use this for initialization
	void Start () {
		gameController = GetComponent<GameController> ();
		player = gameController.playerController;
	}
	
	// Update is called once per frame
	void Update () {
		if (bulletEnable == false) {
			GUI.Label (new Rect(75, 1000, 300, 225), "Bullet Time Ready");
		}
		//Bullet Time
		if (Input.GetKeyDown (KeyCode.F) && bulletEnable == true) {
			bulletEnable = false;
			StartCoroutine("startBulletTime");
		}
			if (Time.timeScale == convert(effectiveness)) {
				bulletTimer += Time.deltaTime;
			}
			if (bulletTimer > duration) {
				bulletTimer = 0;
				Time.timeScale = 1f;
			}
			//Shield
		 
		if (Input.GetKeyDown (KeyCode.E)) {
			StartCoroutine("enableShield");
			Debug.Log ("SHIELD ACTIVATED");
			}
		if (player.shieldOn == true) {
			shieldTimer += Time.deltaTime;
		}
		if (shieldTimer > player.shieldDuration) {
			player.shieldOn = false;
		}
	}
	IEnumerator startBulletTime(){
		if (Time.timeScale == 1.0f) {
			Time.timeScale = convert(effectiveness);
		} else {
			Time.timeScale = 1.0f;
		}
		yield return new WaitForSeconds(duration + cooldown);
		bulletEnable = true;
	}

	IEnumerator enableShield(){
		player.shieldEnable = false;
		player.shieldOn = true;
		yield return new WaitForSeconds (player.shieldDuration+ cooldown);
		player.shieldEnable = true;

	}

	float convert(float current){
		timeScale = 1 - (current);
		return timeScale;
	}
	
}
