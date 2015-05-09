using UnityEngine;
using System.Collections;

public class SpawnSpawnerBehaviour : MonoBehaviour 
{
	public GameObject spawnee;

	GameObject spawneeClone;
	GameObject player;

	public bool enabled;
	public float cooldown;
	public float delay;
	public float spawnDistance;
	
	bool spawnable;
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");

		spawnable = true;
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if(Vector3.Distance(transform.position, player.transform.position) < spawnDistance)
		{
			enabled = true;
		}
		else 
		{
			enabled = false;
		}

		if(enabled && spawnable)
		{
			StartCoroutine("Spawn");
		}
	}
	
	// Spawns the spawnee when the Spawn button in the inspector is activated
	public void SpawnButton()
	{
		if(spawnable)
		{
			StartCoroutine("Spawn");
		}
	}
	
	IEnumerator Spawn()
	{
		spawnable = false;
		yield return new WaitForSeconds(delay);
		delay = 0f;
		spawneeClone = Instantiate(spawnee);

		spawneeClone.transform.position = transform.position;
		spawneeClone.transform.rotation = transform.rotation;
		yield return new WaitForSeconds(cooldown);
		spawnable = true;
	}
}
