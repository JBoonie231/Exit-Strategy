using UnityEngine;
using System.Collections;

public class m9_Fire : MonoBehaviour 
{
	
	public GameObject Bullet;
	public AudioClip M9Fire;
	public AudioClip M9Reload;
	public float Volume = 1.0f;
	public int ClipSize = 9;
	public float ReloadTime = .3f;
	public float damage = 1f;
	GameObject particles;
	private AudioSource source;
	public int shots = 0; 
	private bool CanFire = true; 

	//for muzzle flash
	public GameObject muzzleLight;
	
	void Awake ()
	{
		source = GetComponent<AudioSource> ();
		CanFire = true; 
		//muzzleLight.gameObject.SetActive (false); 
		particles = GameObject.FindGameObjectWithTag ("m9 Fire Particle");
		particles.gameObject.SetActive (false);
	}
	
	void Update ()
	{
		
		if (Input.GetButtonDown ("Fire1")) 
		{
			if (CanFire){
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
			
			source.PlayOneShot (M9Fire, Volume);
			
			shots = shots + 1;
			particles.gameObject.SetActive(true);
			//muzzleLight.gameObject.SetActive (true);
			StartCoroutine(LightFlash());

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

	IEnumerator LightFlash ()
	{
		yield return new WaitForSeconds (0.1f);
		//muzzleLight.gameObject.SetActive (false);
		particles.active = false;
	}
	
}
