using UnityEngine;
using System.Collections;

public class FollowMotionPath : MonoBehaviour
{
	public MotionPath motionPath;
	public float startPosition;
	public float speed;										// Realworld units per second you want your object to travel
	public bool loop;
	public bool pause = false;
	private Triggers trigger;
	private SpawnerBehaviour spawner;
	float uv;
	
	void Start()
	{
		uv = startPosition;
		if (motionPath == null)
			enabled = false;
	}
	
	
	void FixedUpdate()
	{
		if (!pause) {
			uv += ((speed / motionPath.length) * Time.fixedDeltaTime);			// This gets you uv amount per second so speed is in realworld units
			if (loop)
				uv = (uv < 0 ? 1 + uv : uv) % 1;
			else if (uv > 1)
				enabled = false;
			Vector3 pos = motionPath.PointOnNormalizedPath (uv);
			Vector3 norm = motionPath.NormalOnNormalizedPath (uv);
		
			transform.position = pos;
			transform.forward = speed > 0 ? norm : -norm;
		}
	}

	void OnTriggerEnter(Collider other){
		Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "stopPoint") {
			pause = true;
			Debug.Log ("STOP POINT DETECTED");
			Debug.Log ("Spawning enemies");
			trigger = other.gameObject.GetComponent<Triggers>();
			if( trigger.spawner1 != null){
				trigger.spawner1.enabled = true;
			}
			if( trigger.spawner2 != null){
				trigger.spawner2.enabled = true;
			}
			if( trigger.spawner3 != null){
				trigger.spawner3.enabled = true;
			}
			if( trigger.spawner4 != null){
				trigger.spawner4.enabled = true;
			}
			if( trigger.spawner5 != null){
				trigger.spawner5.enabled = true;
			}

			Destroy (other.gameObject);

		}	
		else if (other.gameObject.tag == "Change Rail") {
			trigger = other.gameObject.GetComponent<Triggers>();
			motionPath = trigger.motionPath;
			uv = 0;
			Debug.Log ("Rail change detected");
		}
	} 
}
	

