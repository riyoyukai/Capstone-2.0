using UnityEngine;
using System.Collections;

/// <summary>
/// from http://forum.unity3d.com/threads/animal-ai-random-movements.304868/
/// by http://forum.unity3d.com/members/lineupthesky.762934/
/// </summary>
public class NewWander : MonoBehaviour {

	private float directionChangeInterval = 1;
	private float maxHeadingChange = 50;
	
	CharacterController controller;
	float heading;
	Vector3 targetRotation;
	
	private float speed = 3;
	private float randomX = 10;
	private float randomZ = 10;
	private float minWaitTime = 1;
	private float maxWaitTime = 5;
	private Vector3 currentRandomPos;

	void Awake (){
		controller = GetComponent<CharacterController>();
		
		// Set random initial rotation
		heading = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, heading, 0);
	}

	void Start(){
		PickPosition();
	}
	
	void PickPosition(){
		currentRandomPos = new Vector3(Random.Range(-randomX, randomX), 0, Random.Range(-randomZ, randomZ));
		StartCoroutine ( MoveToRandomPos());
		print ("Picking new position: " + currentRandomPos.x + ", " + currentRandomPos.z);
	}
	
	void Update (){
		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		var forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove(forward * speed);
	}
	
	IEnumerator MoveToRandomPos(){
		float i = 0.0f;
		float rate = 1.0f / speed;
		Vector3 currentPos = transform.position;
		
		while (i < 1.0f) {
			NewHeadingRoutine();
			yield return new WaitForSeconds(directionChangeInterval);
		}
		
		float randomFloat = Random.Range(0.0f,1.0f); // Create %50 chance to wait
		if(randomFloat < 0.5f)
			StartCoroutine ( WaitForSomeTime());
		else
			PickPosition();
	}
	
	IEnumerator WaitForSomeTime(){
		print ("Waiting...");
		yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
		PickPosition();
	}
	
	/// <summary>
	/// Calculates a new direction to move towards.
	/// </summary>
	void NewHeadingRoutine (){
		var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
		var ceil  = Mathf.Clamp(heading + maxHeadingChange, 0, 360);
		heading = Random.Range(floor, ceil);
		targetRotation = new Vector3(0, heading, 0);
	}
}
