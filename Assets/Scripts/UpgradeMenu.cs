using UnityEngine;
using System.Collections;

public class UpgradeMenu : MonoBehaviour {
	GUISkin newSkin;
	Powers powers;
	GameController gameController;
	PlayerController player;
	public m9_Fire m9;
	public Repeater_Fire repeater;


	public void theUpgradeMenu()
	{

		gameController = GetComponent<GameController> ();
		m9 = gameController.m9;
		repeater = gameController.repeater;
		player = gameController.playerController;
		//m9 = GetComponent<m9_Fire> ();
		//the menu background box



		GUI.BeginGroup (new Rect (100, 380, 200, 200));
		GUI.Box (new Rect (0, 0, 200, 200), "Shield");
		GUI.Label (new Rect (75, 25, 300, 225), "Duration");
		GUI.Label (new Rect (95, 52, 300, 225), player.shieldDuration.ToString ());
		if (GUI.Button (new Rect (10, 52, 25, 25), "-")) {
			if (player.shieldDuration > 0) {
				player.shieldDuration -= 1;
				gameController.upgradeCredits ++;
			}
		}
		if (GUI.Button (new Rect (170, 52, 25, 25), "+")) {
			if (player.shieldDuration < 10 && gameController.upgradeCredits > 0) {
				player.shieldDuration += 1;
				gameController.upgradeCredits --;
			}
		}
		GUI.Label (new Rect (60, 85, 300, 225), "Effectiveness");
		GUI.Label (new Rect (95, 115, 300, 225), (1 - player.shieldDamage).ToString ());
		if (GUI.Button (new Rect (10, 115, 25, 25), "-")) {
			if (player.shieldDamage < 1f) {
				player.shieldDamage += .1f;
				gameController.upgradeCredits ++;
			}
		}
		if (GUI.Button (new Rect (170, 115, 25, 25), "+")) {
			if (player.shieldDamage > .1f && gameController.upgradeCredits > 0) {
				player.shieldDamage -= .1f;
				gameController.upgradeCredits --;
			}
		}
		GUI.EndGroup ();



		GUI.BeginGroup (new Rect (410, 380, 200, 200));
		GUI.Box (new Rect (0, 0, 200, 200), "Bullet Time");
		GUI.Label (new Rect (75, 25, 300, 225), "Duration");
		GUI.Label (new Rect (95, 52, 300, 225), powers.duration.ToString ());
		if (GUI.Button (new Rect (10, 52, 25, 25), "-")) {
			if (powers.duration > 0) {
				powers.duration -= 1f;
				gameController.upgradeCredits ++;
			}

		}
		if (GUI.Button (new Rect (170, 52, 25, 25), "+")) {
			if (powers.duration < 10 && gameController.upgradeCredits > 0) {
				powers.duration += 1f;
				gameController.upgradeCredits --;
			}
		}
		GUI.Label (new Rect (65, 85, 300, 225), "Effectiveness");
		GUI.Label (new Rect (95, 115, 300, 225), powers.effectiveness.ToString ());
		if (GUI.Button (new Rect (10, 115, 25, 25), "-")) {
			if (powers.effectiveness > .1f) {
				powers.effectiveness -= .1f;
				gameController.upgradeCredits ++;
			}
		}
		if (GUI.Button (new Rect (170, 115, 25, 25), "+")) {
			if (powers.effectiveness <= .7f && gameController.upgradeCredits > 0) {
				powers.effectiveness += .1f;
				gameController.upgradeCredits --;
			}
		}
		GUI.EndGroup ();

		GUI.BeginGroup (new Rect (720, 380, 200, 200));
		GUI.Box (new Rect (0, 0, 200, 200), "Player");
		GUI.Label (new Rect (75, 25, 300, 225), "Max Health");
		GUI.Label (new Rect (95, 52, 300, 225), player.maxHealth.ToString ());
		if (GUI.Button (new Rect (10, 52, 25, 25), "-")) {
			if (player.maxHealth > 100) {
				player.maxHealth -= 1f;
				gameController.upgradeCredits ++;
			}
			
		}
		if (GUI.Button (new Rect (170, 52, 25, 25), "+")) {
			if (player.maxHealth < 125 && gameController.upgradeCredits > 0) {
				player.maxHealth += 1f;
				gameController.upgradeCredits --;
			}
		}

		GUI.EndGroup ();

		GUI.BeginGroup (new Rect (1030, 380, 200, 200));
		GUI.Box (new Rect (0, 0, 200, 200), "M9");
		GUI.Label (new Rect (75, 25, 300, 225), "Damage");
		GUI.Label (new Rect (95, 55, 300, 225), m9.damage.ToString ());
		if (GUI.Button (new Rect (10, 52, 25, 25), "-")) {
			if (m9.damage > 1f) {
				m9.damage -= .1f;
				gameController.upgradeCredits++;
			} 
		}
		if (GUI.Button (new Rect (170, 52, 25, 25), "+")) {
			if (m9.damage < 1.5f && gameController.upgradeCredits > 0) {
				m9.damage += .1f;
				gameController.upgradeCredits --;
			}
		}
		GUI.Label (new Rect (73, 82, 300, 225), "Clip Size");
		GUI.Label (new Rect (95, 115, 300, 225), m9.ClipSize.ToString ());
		if (GUI.Button (new Rect (10, 115, 25, 25), "-")) {
			if (m9.ClipSize > 9) {
				m9.ClipSize -= 1;
				gameController.upgradeCredits++;
			} 
			
		}
		if (GUI.Button (new Rect (170, 115, 25, 25), "+")) {
			if (m9.ClipSize < 17 && gameController.upgradeCredits > 0) {
				m9.ClipSize += 1;
				gameController.upgradeCredits --;
			}
		}
		GUI.EndGroup ();
		GUI.BeginGroup (new Rect (1340, 380, 200, 200));
		GUI.Box (new Rect (0, 0, 200, 200), "M9");
		GUI.Label (new Rect (75, 25, 300, 225), "Damage");
		GUI.Label (new Rect (95, 55, 300, 225), repeater.damage.ToString ());
		if (GUI.Button (new Rect (10, 52, 25, 25), "-")) {
			if (repeater.damage > .5f) {
				repeater.damage -= .1f;
				gameController.upgradeCredits++;
			} 
		}
		if (GUI.Button (new Rect (170, 52, 25, 25), "+")) {
			if (repeater.damage < 1f && gameController.upgradeCredits > 0) {
				repeater.damage += .1f;
				gameController.upgradeCredits --;
			}
		}
		GUI.Label (new Rect (73, 82, 300, 225), "Clip Size");
		GUI.Label (new Rect (95, 115, 300, 225), repeater.ClipSize.ToString ());
		if (GUI.Button (new Rect (10, 115, 25, 25), "-")) {
			if (repeater.ClipSize > 30) {
				repeater.ClipSize -= 1;
				gameController.upgradeCredits++;
			} 
			
		}
		if (GUI.Button (new Rect (170, 115, 25, 25), "+")) {
			if (repeater.ClipSize < 50 && gameController.upgradeCredits > 0) {
				repeater.ClipSize += 1;
				gameController.upgradeCredits --;
			}
		}
		GUI.Label (new Rect (73, 145, 300, 225), "Speed");
		GUI.Label (new Rect (95, 175, 300, 225), (1-repeater.RateOfFire).ToString ());
		if (GUI.Button (new Rect (10, 175, 25, 25), "-")) {
			if (repeater.RateOfFire < .5f) {
				repeater.RateOfFire += .1f;
				gameController.upgradeCredits++;
			} 
			
		}
		if (GUI.Button (new Rect (170, 175, 25, 25), "+")) {
			if (repeater.RateOfFire > .2f && gameController.upgradeCredits > 0) {
				repeater.RateOfFire -= .1f;
				gameController.upgradeCredits --;
			}
		}
		GUI.EndGroup ();
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
