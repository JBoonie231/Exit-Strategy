using UnityEngine;
using System.Collections;

public class Laser_Toggle : MonoBehaviour {

	public AudioClip Toggle;
	public float Volume = 1.0f;
	public Renderer laser;
	private AudioSource source;
	
	void Start () 
	{
		source = GetComponent<AudioSource> ();
		laser = GetComponent<Renderer> ();
		laser.enabled = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("f"))
		{
			if(laser.enabled == false)
			{
				laser.enabled = true;
				source.PlayOneShot (Toggle, Volume);
			}

			else
			{
				laser.enabled = false;
				source.PlayOneShot (Toggle, Volume);
			}
		}
	}
}
