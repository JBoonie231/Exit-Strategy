using UnityEngine;
using System.Collections;

public class FollowMotionPath : MonoBehaviour
{
	public MotionPath motionPath;
	public float startPosition;
	public float speed;										// Realworld units per second you want your object to travel
	public bool loop;
	public bool pause = false;
	private RailSwitcher railSwitcher;
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
			Destroy (other.gameObject);
			Debug.Log ("STOP POINT DETECTED");
		}	
		else if (other.gameObject.tag == "Change Rail") {
			railSwitcher = other.gameObject.GetComponent<RailSwitcher>();
			motionPath = railSwitcher.motionPath;
			uv = 0;
			Debug.Log ("Rail change detected");
		}
	} 
}
	

