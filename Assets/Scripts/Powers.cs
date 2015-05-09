using UnityEngine;
using System.Collections;

public class Powers : MonoBehaviour {
	public float effectiveness = 0.1f;
	public float duration = 0.0f;
	public float bulletTimer;
	public float shieldTimer;
	public float cooldown = 20f;
	public bool bulletEnable = true;
	public float timeScale;
	public GameController gameController;
	public PlayerController player;
	public GameObject Shield;
	MeshRenderer rend;

	// Use this for initialization
	void Start () {
		gameController = GetComponent<GameController> ();
		player = gameController.playerController;
		
		rend = gameController.Shield.GetComponent<MeshRenderer> ();//Used for shield
		//rend.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (player.shieldOn == true) {//If shield is on, show shield object
			rend.enabled = true;
		} else {
			rend.enabled = false;
		}
		if (bulletEnable == false) {
			GUI.Label (new Rect(75, 1000, 300, 225), "Bullet Time Ready");//Notify user that bullet time is ready
		}
		//enabled bullet time
		if (Input.GetKeyDown (KeyCode.F) && bulletEnable == true) {
			bulletEnable = false;
			StartCoroutine("startBulletTime");
		}
			if (Time.timeScale == convert(effectiveness)) { //Increase counter to expire bullet time
				bulletTimer += Time.deltaTime;
			}
			if (bulletTimer > duration) {//Bullet time has expired
				bulletTimer = 0;
				Time.timeScale = 1f;
			}
			
		 //Emable shield
		if (Input.GetKeyDown (KeyCode.E)) {
			if(player.shieldEnable == true){
				StartCoroutine("enableShield");


			}
		

			}
		if (player.shieldOn == true) { //Increase counter to expire bullet time
			shieldTimer += Time.deltaTime;
		}
		if (shieldTimer > player.shieldDuration) { //Shield timer has expired
			shieldTimer = 0;
			player.shieldOn = false;

		}
	}
	//Set proper timeScale and set cooldown
	IEnumerator startBulletTime(){
		if (Time.timeScale == 1.0f) {
			Time.timeScale = convert(effectiveness);
		} else {
			Time.timeScale = 1.0f;
		}
		yield return new WaitForSeconds(duration + cooldown);
		bulletEnable = true;
	}
	//Enable shield and set cooldown
	IEnumerator enableShield(){
		player.shieldEnable = false;
		player.shieldOn = true;
		yield return new WaitForSeconds (player.shieldDuration + cooldown);
		player.shieldEnable = true;

	}
	//Used to properly display value on upgrade menu
	float convert(float current){
		timeScale = 1 - (current);
		return timeScale;
	}
	
}
