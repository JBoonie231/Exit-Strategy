using UnityEngine;
using System.Collections;

public class UnityFlockController : MonoBehaviour
{
    public Vector3 bound;
    //public float speed = 100.0f;
	public float distance = 5f;
	public GameObject enemyShip;
	public GameObject enemy0;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
    private Vector3 initialPosition;
    private Vector3 nextMovementPoint;

    // Use this for initialization
    void Start()
    {

        initialPosition = transform.position;
       // CalculateNextMovementPoint();
    }

	void Update(){
		transform.position = transform.parent.position + transform.forward * distance;


	}
}