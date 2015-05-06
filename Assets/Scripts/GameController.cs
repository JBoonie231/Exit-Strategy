﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject player;
	public GameObject Shield;
	public PlayerController playerController;
	public GameObject movementController;
	GameObject currentTriggerObject;
	PauseMenu pauseMenu;
	GameObject[] enemies;
	Powers powers;
	public m9_Fire m9;
	public int upgradeCredits;
	public int kills;
	public int tempKillCount;

	Triggers trigger;
	float spawnTime;

	// Use this for initialization
	void Start () 
	{
		Time.timeScale = 1f;
		Cursor.visible = false;
		player = GameObject.FindGameObjectWithTag("Player");
		playerController =player.GetComponent<PlayerController> ();
		movementController = GameObject.FindGameObjectWithTag("Movement Controller");
		powers = gameObject.AddComponent<Powers> ();
		m9 = GameObject.FindGameObjectWithTag("m9").GetComponent<m9_Fire> ();
	}
	
	// Update is called once per frame
	void Update () 
	{

		enemies = GameObject.FindGameObjectsWithTag("Enemy");

		if(currentTriggerObject != null)
		{
			TryToStopSpawners();
		}
		if(Input.GetKey("escape")) 
		{
			Cursor.visible = true;
			Time.timeScale = 0.0f;
			player.gameObject.active = false;
			if(pauseMenu == null){
				pauseMenu = gameObject.AddComponent<PauseMenu>();
			}

		}

	}


	public void StartSpawners(GameObject trigger)
	{
		foreach(GameObject enemy in enemies)
		{
			Destroy(enemy);
		}

		currentTriggerObject = trigger;


		this.trigger = currentTriggerObject.GetComponent<Triggers>();
		if( this.trigger.spawner1 != null){
			this.trigger.spawner1.enabled = true;
		}
		if( this.trigger.spawner2 != null){
			this.trigger.spawner2.enabled = true;
		}
		if( this.trigger.spawner3 != null){
			this.trigger.spawner3.enabled = true;
		}
		if( this.trigger.spawner4 != null){
			this.trigger.spawner4.enabled = true;
		}
		if( this.trigger.spawner5 != null){
			this.trigger.spawner5.enabled = true;
		}

		tempKillCount = 0;
		spawnTime = Time.time + this.trigger.howLong;
		//Destroy (currentTriggerObject);
	}

	void TryToStopSpawners()
	{
		if(trigger.timer && trigger.kills && tempKillCount >= trigger.numberOfKills && spawnTime <= Time.time)
		{
			StopSpawners();
		}
		else if(trigger.timer && !trigger.kills && spawnTime <= Time.time)
		{
			StopSpawners();
		}
		else if(trigger.kills && !trigger.timer && tempKillCount >= trigger.numberOfKills)
		{
			StopSpawners();
		}
	}

	void StopSpawners()
	{
		if( trigger.spawner1 != null){
			trigger.spawner1.enabled = false;
		}
		if( trigger.spawner2 != null){
			trigger.spawner2.enabled = false;
		}
		if( trigger.spawner3 != null){
			trigger.spawner3.enabled = false;
		}
		if( trigger.spawner4 != null){
			trigger.spawner4.enabled = false;
		}
		if( trigger.spawner5 != null){
			trigger.spawner5.enabled = false;
		}
		
		if(enemies == null || enemies.Length == 0)
		{
			Destroy (currentTriggerObject);
			movementController.GetComponent<FollowMotionPath>().pause = false;
		}
	}
	void OnGUI(){
		int bulletsLeft = m9.ClipSize - m9.shots;
		//GUI.Label (new Rect (75, 25, 300, 225), "Health ");
		GUI.Label (new Rect(75, 800, 300, 225), "Health " + playerController.health.ToString());
		GUI.Label (new Rect(75, 825, 300, 225), "Lives " + playerController.lives.ToString());
		GUI.Label (new Rect(75, 850, 300, 225), "Magazine " + bulletsLeft.ToString());
		if (playerController.shieldEnable == true) {
			GUI.Label (new Rect (75, 875, 300, 225), "Shield Ready");
		}
		if (powers.bulletEnable == true) {
			GUI.Label (new Rect(75, 900, 300, 225), "Bullet Time Ready");
		}
		
	}
}
