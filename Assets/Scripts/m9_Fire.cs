using UnityEngine;
using System.Collections;

public class m9_Fire : MonoBehaviour 
{
	
	public GameObject Bullet;
	public AudioClip M9Fire;
	public AudioClip M9Reload;
	public float Volume = 1.0f;
	public int ClipSize = 12;
	public float ReloadTime = .3f;
	public float damage = 1f;
	
	private AudioSource source;
	private int shots = 0; 
	private bool CanFire = true; 
	
	void Awake ()
	{
		source = GetComponent<AudioSource> ();
		CanFire = true; 
	}
	
	void Update ()
	{
		
		Vector3 mousePos = Input.mousePosition;
		transform.LookAt(Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10.0f)));
		
		if (Input.GetButtonDown ("Fire1")) 
		{
			if (CanFire)
				Fire();
		}
		
		if (Input.GetKey ("r")) 
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
			
			source.PlayOneShot (M9Fire, Volume);
			
			shots = shots + 1;
		}
		
		if (CanFire == false) 
		{
			StartCoroutine(Reload (ReloadTime));
		}
		
		
	}
	
	IEnumerator Reload (float wait)
	{
		source.PlayOneShot(M9Reload, Volume);
		yield return new WaitForSeconds (wait);
		
		shots = 0;
		CanFire = true;
		
	}
	
}
