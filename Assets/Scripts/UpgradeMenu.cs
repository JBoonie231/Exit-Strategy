using UnityEngine;
using System.Collections;

public class UpgradeMenu : MonoBehaviour {
	GUISkin newSkin;
	Powers powers;
	GameController gameController;
	PlayerController player;
	public m9_Fire m9;
	public int upgradeCredits =5;
	public void theUpgradeMenu()
	{

		gameController = GetComponent<GameController> ();
		m9 = gameController.m9;
		player = gameController.playerController;
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
				upgradeCredits++;
			} 
		}
		if (GUI.Button (new Rect (170, 52, 25, 25), "+")) 
		{
			if(m9.damage < 1.5f ){
				m9.damage += .1f;
				upgradeCredits --;
			}
		}
		GUI.Label (new Rect(73, 82, 300, 225), "Clip Size");
		GUI.Label (new Rect(95, 115, 300, 225), m9.ClipSize.ToString());
		if (GUI.Button (new Rect (10, 115, 25, 25), "-")) 
		{
			if(m9.ClipSize > 9 ){
				m9.ClipSize -= 1;
				upgradeCredits++;
			} 

		}
		if (GUI.Button (new Rect (170, 115, 25, 25), "+")) 
		{
			if(m9.ClipSize < 17 ){
				m9.ClipSize += 1;
				upgradeCredits --;
			}
		}
		GUI.EndGroup ();


		GUI.BeginGroup(new Rect(100, 375, 200, 200));
		GUI.Box(new Rect(0, 0, 200, 200), "Shield");
		GUI.Label (new Rect(75, 25, 300, 225), "Duration");
		GUI.Label (new Rect(95, 52, 300, 225), player.shieldDuration.ToString ());
		if (GUI.Button (new Rect (10, 52, 25, 25), "-")) 
		{
			if(player.shieldDuration > 0){
				player.shieldDuration -= 1;
				upgradeCredits ++;
			}
		}
		if (GUI.Button (new Rect (170, 52, 25, 25), "+")) 
		{
			if(player.shieldDuration < 10){
				player.shieldDuration += 1;
				upgradeCredits --;
			}
		}
		GUI.Label (new Rect(60, 85, 300, 225), "Effectiveness");
		GUI.Label (new Rect(95, 115, 300, 225), (1-player.shieldDamage).ToString ());
		if (GUI.Button (new Rect (10, 115, 25, 25), "-")) 
		{
			if(player.shieldDamage < 1f){
				player.shieldDamage += .1f;
				upgradeCredits ++;
			}
		}
		if (GUI.Button (new Rect (170, 115, 25, 25), "+")) 
		{
			if(player.shieldDamage > .1f){
				player.shieldDamage -= .1f;
				upgradeCredits --;
			}
		}
		GUI.EndGroup ();



		GUI.BeginGroup(new Rect(410, 375, 200, 200));
		GUI.Box(new Rect(0, 0, 200, 200), "Bullet Time");
		GUI.Label (new Rect(75, 25, 300, 225), "Duration");
		GUI.Label (new Rect (95, 52, 300, 225), powers.duration.ToString ());
		if (GUI.Button (new Rect (10, 52, 25, 25), "-")) 
		{
			if(powers.duration > 0 ){
				powers.duration -= 1f;
				upgradeCredits ++;
			}

		}
		if (GUI.Button (new Rect (170, 52, 25, 25), "+")) 
		{
			if(powers.duration < 10 ){
				powers.duration += 1f;
				upgradeCredits --;
			}
		}
		GUI.Label (new Rect(65, 85, 300, 225), "Effectiveness");
		GUI.Label (new Rect (95, 115, 300, 225), powers.effectiveness.ToString ());
		if (GUI.Button (new Rect (10, 115, 25, 25), "-")) 
		{
			if(powers.effectiveness > .1f ){
				powers.effectiveness -= .1f;
				upgradeCredits ++;
			}
		}
		if (GUI.Button (new Rect (170, 115, 25, 25), "+")) 
		{
			if(powers.effectiveness <= .7f){
				powers.effectiveness += .1f;
				upgradeCredits --;
			}
		}
		GUI.EndGroup ();

		GUI.BeginGroup(new Rect(720, 375, 200, 200));
		GUI.Box(new Rect(0, 0, 200, 200), "Player");
		GUI.Label (new Rect(75, 25, 300, 225), "Max Health");
		GUI.Label (new Rect (95, 52, 300, 225), player.maxHealth.ToString ());
		if (GUI.Button (new Rect (10, 52, 25, 25), "-")) 
		{
			if(player.maxHealth > 10 ){
				player.maxHealth -= 1f;
				upgradeCredits --;
			}
			
		}
		if (GUI.Button (new Rect (170, 52, 25, 25), "+")) 
		{
			if(player.maxHealth < 15 ){
				player.maxHealth += 1f;
				upgradeCredits --;
			}
		}
		GUI.Label (new Rect(75, 85, 300, 225), "Something else?");
		GUI.Label (new Rect (100, 115, 300, 225), "Something" );
		if (GUI.Button (new Rect (10, 115, 25, 25), "-")) 
		{
			if(false){

				upgradeCredits ++;
			}
		}
		if (GUI.Button (new Rect (170, 115, 25, 25), "+")) 
		{
			if(false){

				upgradeCredits --;
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
