using UnityEngine;
using System.Collections;

public class SpawnerBehaviour : MonoBehaviour 
{
	public GameObject spawnee;
	public GameObject[] waypoints;
	//public int numberOfSpawns;
	GameObject spawneeClone;
	GameObject tempWaypoint;
	public GameObject particles1;
	public GameObject particles2;
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
		if (enabled && particles1 != null && particles2 != null) {
			particles1.SetActive (true);
			particles2.SetActive (true);
		} else if(!enabled && particles1 != null && particles2 != null){
			particles1.SetActive(false);
			particles2.SetActive(false);
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
		if(waypoints.Length != 0)
		{
			tempWaypoint = waypoints[Random.Range(0, waypoints.Length)];
			if(!tempWaypoint.GetComponent<EnemyWaypointBehaviour>().occupied)
			{
				tempWaypoint.GetComponent<EnemyWaypointBehaviour>().occupied = true;
				spawnable = false;
				spawneeClone = Instantiate(spawnee);
				spawneeClone.transform.position = transform.position;
				spawneeClone.transform.rotation = transform.rotation;
				//spawneeClone.GetComponentInChildren<AlienSoldierBehaviour>().tag = "Enemy";
				spawneeClone.GetComponentInChildren<AlienSoldierBehaviour>().target = tempWaypoint;
				yield return new WaitForSeconds(cooldown);
				spawnable = true;
			}
		}
	}


}
