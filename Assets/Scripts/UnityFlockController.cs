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
		if (enemy0 == null) {
			enemy0 = Instantiate (enemyShip);
		} else if (enemy1 == null) {
			enemy1 = Instantiate (enemyShip);
		} else if (enemy2 == null) {
			enemy2 = Instantiate (enemyShip);
		} else if (enemy3 == null) {
			enemy3 = Instantiate (enemyShip);
		} else if (enemy4 == null) {
			enemy4 = Instantiate (enemyShip);
		}

	}
	/*
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(nextMovementPoint - transform.position), 1.0f * Time.deltaTime);

        if (Vector3.Distance(nextMovementPoint, transform.position) <= 10.0f)
            CalculateNextMovementPoint();
    }
    


	
	void CalculateNextMovementPoint()
	{
		float posX = Random.Range(initialPosition.x - bound.x, initialPosition.x + bound.x);
		float posY = Random.Range(initialPosition.y - bound.y, initialPosition.y + bound.y);
		float posZ = Random.Range(initialPosition.z - bound.z, initialPosition.z + bound.z);
		
		nextMovementPoint = initialPosition + new Vector3(posX, posY, posZ);
	}
	*/
}