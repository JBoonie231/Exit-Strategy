using UnityEngine;
using System.Collections;

public class m9_Fire : MonoBehaviour 
{

	public GameObject Bullet;
	public AudioClip M9Fire;
	public float Volume = 1.0f;

	private AudioSource source;

	void Awake ()
	{
		source = GetComponent<AudioSource> ();
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			GameObject clone;
			clone = Instantiate (Bullet, transform.position, transform.rotation) as GameObject;

			source.PlayOneShot(M9Fire, Volume);

		}

	}
}
