using UnityEngine;
using System.Collections;

public class SpawnerBehaviour : MonoBehaviour 
{
	public GameObject spawnee;
	public GameObject[] waypoints;
	public int numberOfSpawns;
	GameObject spawneeClone;

	public bool enabled;
	public float cooldown;

	bool spawnable;

	// Use this for initialization
	void Start () 
	{
		spawnable = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(enabled && spawnable)
		{
			if(numberOfSpawns > 0){
				StartCoroutine("Spawn");
				numberOfSpawns--;
			}
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

		spawneeClone = Instantiate(spawnee);
		if(waypoints.Length != 0)
		{
			spawneeClone.GetComponentInChildren<AlienSoldierBehaviour>().target = waypoints[Random.Range(0, waypoints.Length - 1)];
		}
		yield return new WaitForSeconds(cooldown);
		spawnable = true;
	}
}
