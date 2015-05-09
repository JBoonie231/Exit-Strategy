using UnityEngine;
using System.Collections;

public class Triggers : MonoBehaviour {

	//Stores spawners and queen to enable when trigger is reached. Also
	//Sets how many kills or how much time in order to trigger the deactivation
	//of the spanwers
	public MotionPath motionPath; //used to switch rails if necessary
	public bool timer;
	public bool kills;
	public float howLong;
	public int numberOfKills;
	public AlienQueenBehaviour queen;
	public SpawnerBehaviour spawner1;
	public SpawnerBehaviour spawner2;
	public SpawnerBehaviour spawner3;
	public SpawnerBehaviour spawner4;
	public SpawnerBehaviour spawner5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
