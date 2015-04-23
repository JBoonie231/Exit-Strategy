using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
	GUISkin newSkin;
	Texture2D logoTexture;
	
	public void thePauseMenu()
	{
		//layout start
		GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 250));
		
		
		//the menu background box
		
		GUI.Box(new Rect(0, 0, 300, 250), "");
		
		//logo picture
		
		GUI.Label(new Rect(15, 10, 300, 68), logoTexture);
		
		
		///////pause menu buttons
		
		//game resume button
		
		if(GUI.Button(new Rect(55, 100, 180, 40), "Resume"))
			
		{

			//GUI.BeginGroup = null;
			Time.timeScale = 1.0f;
			this.enabled = false;
			GameController gC = this.GetComponentInParent<GameController>();
			gC.player.active = true;
			Destroy(this);

			
		}
		
		
		//main menu 
		
		if(GUI.Button(new Rect(55, 150, 180, 40), "Main Menu"))
			
		{
			LevelChange lC = gameObject.AddComponent<LevelChange>();
			lC.loadTitle();
			//Application.LoadLevel("Title");
			
		}
		
		
		//quit button
		
		if(GUI.Button(new Rect(55, 200, 180, 40), "Quit"))
			
		{
			
			Application.Quit();
			
		}
		
		
		//layout end
		
		GUI.EndGroup();
		
		
	}
	
	
	void OnGUI ()
		
	{
		
		//load GUI skin
		
		GUI.skin = newSkin;
		
		
		//show the mouse cursor
		
		Cursor.visible = true;
		
		
		//run the pause menu script
		
		thePauseMenu();
		
	}
	
}