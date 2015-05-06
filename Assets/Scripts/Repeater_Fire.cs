using UnityEngine;
using System.Collections;

public class Repeater_Fire : MonoBehaviour {
	
	public GameObject Bullet;
	public AudioClip RFire;
	public AudioClip Repeater_Reload;
	public float Volume = 1.0f;
	public int ClipSize = 30;
	public float ReloadTime = 2.5f;
	public float damage = .1f;
	public float RateOfFire = .5f;
	
	private AudioSource source;
	public int shots = 0; 
	private bool CanFire = true; 
	private bool RateCap = true; 
	
	void Awake ()
	{
		source = GetComponent<AudioSource> ();
		CanFire = true; 
		RateCap = true;
	}
	
	void Update ()
	{
		
		if (Input.GetKey (KeyCode.Mouse0)) 
		{
			if ((CanFire)&&(RateCap))
			{
				Fire();
			}
			
		}
		
		if (Input.GetKeyDown ("r")) 
		{
			CanFire = false;
			StartCoroutine(Reload (ReloadTime));
		}
		
	}
	
	void Fire()
	{
		
		if (shots == ClipSize) 
		{
			CanFire = false;
		}
		
		if (CanFire) 
		{
			GameObject clone;
			clone = Instantiate (Bullet, transform.position, transform.rotation) as GameObject;
			
			source.PlayOneShot (RFire, Volume);
			
			shots = shots + 1;
			
			RateCap = false;
			StartCoroutine(Delay (RateOfFire));
			
		}
		
		if (CanFire == false) 
		{
			StartCoroutine(Reload (ReloadTime));
		}
		
		
	}
	
	IEnumerator Reload (float wait)
	{
		source.PlayOneShot(Repeater_Reload, Volume);
		yield return new WaitForSeconds (wait);
		
		shots = 0;
		CanFire = true;
		
	}
	
	IEnumerator Delay (float wait)
	{
		yield return new WaitForSeconds (wait);
		RateCap = true;
	}
	
}
