﻿using UnityEngine;
using System.Collections;

public class UpgradeMenu : MonoBehaviour {
	GUISkin newSkin;
	Powers powers;
	GameController gameController;
	public m9_Fire m9;
	public void theUpgradeMenu()
	{

		gameController = GetComponent<GameController> ();
		m9 = gameController.m9;

		Debug.Log (m9.damage);
		//m9 = GetComponent<m9_Fire> ();
		//the menu background box
		GUI.BeginGroup (new Rect (100, 100, 200, 200));
		GUI.Box(new Rect(0, 0, 200, 200), "M9");
		GUI.Label (new Rect(75, 25, 300, 225), "Damage");
		GUI.Label (new Rect(95, 55, 300, 225), m9.damage.ToString());
		if (GUI.Button (new Rect (10, 52, 25, 25), "-")) 
		{
			if(m9.damage > 1f ){
				m9.damage -= .1f;
			} 
		}
		if (GUI.Button (new Rect (170, 52, 25, 25), "+")) 
		{
			if(m9.damage < 1.5f ){
				m9.damage += .1f;
			}
		}
		GUI.Label (new Rect(73, 82, 300, 225), "Accuracy");
		
		if (GUI.Button (new Rect (10, 115, 25, 25), "-")) 
		{
			
		}
		if (GUI.Button (new Rect (170, 115, 25, 25), "+")) 
		{
			
		}
		GUI.EndGroup ();
		GUI.BeginGroup(new Rect(100, 375, 200, 200));
		GUI.Box(new Rect(0, 0, 200, 200), "Shield");
		GUI.Label (new Rect(75, 25, 300, 225), "Duration");
		
		if (GUI.Button (new Rect (10, 52, 25, 25), "-")) 
		{
			
		}
		if (GUI.Button (new Rect (170, 52, 25, 25), "+")) 
		{
			
		}
		GUI.Label (new Rect(60, 55, 300, 225), "Effectiveness");
		
		if (GUI.Button (new Rect (10, 22, 25, 25), "-")) 
		{
			
		}
		if (GUI.Button (new Rect (170, 22, 25, 25), "+")) 
		{
			
		}
		GUI.EndGroup ();
		GUI.BeginGroup(new Rect(410, 375, 200, 200));
		GUI.Box(new Rect(0, 0, 200, 200), "Bullet Time");
		GUI.Label (new Rect(75, 25, 300, 225), "Duration");
		GUI.Label (new Rect (95, 52, 300, 225), powers.duration.ToString ());
		if (GUI.Button (new Rect (10, 52, 25, 25), "-")) 
		{
			if(powers.duration > 5 ){
				powers.duration -= 1f;
			}

		}
		if (GUI.Button (new Rect (170, 52, 25, 25), "+")) 
		{
			if(powers.duration < 20 ){
				powers.duration += 1f;
			}
		}
		GUI.Label (new Rect(65, 85, 300, 225), "Effectiveness");
		GUI.Label (new Rect (95, 115, 300, 225), powers.effectiveness.ToString ());
		if (GUI.Button (new Rect (10, 115, 25, 25), "-")) 
		{
			if(powers.effectiveness > .1f ){
				powers.effectiveness -= .1f;
			}
		}
		if (GUI.Button (new Rect (170, 115, 25, 25), "+")) 
		{
			if(powers.effectiveness <= .7f){
				powers.effectiveness += .1f;
			}
		}
		GUI.EndGroup ();
		/*GUI.BeginGroup(new Rect(Screen.width / 2 -100, Screen.height-60, 300, 300));
		if(GUI.Button(new Rect(0, 0, 180, 40), "Return to Game"))
			
		{
			
			//GUI.BeginGroup = null;
			Time.timeScale = 1.0f;
			this.enabled = false;
			GameController gC = this.GetComponentInParent<GameController>();
			gC.player.active = true;
			Destroy(this);
			
			
		}
		GUI.EndGroup ();
		*/
	}
	
	
	void OnGUI ()
		
	{
		powers = GetComponent<Powers> ();


		//load GUI skin
		
		GUI.skin = newSkin;
		
		
		//show the mouse cursor
		
		Cursor.visible = true;
		
		
		//run the pause menu script
		
		theUpgradeMenu();
		
	}
}
