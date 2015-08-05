using UnityEngine;
using System.Collections;

/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// from http://wiki.unity3d.com/index.php/Wander
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class NewWander : MonoBehaviour
{
	private float speed = 1.5f;
	private float directionChangeInterval = 1.5f;
	private float directionChangeIntervalMin = 1;
	private float directionChangeIntervalMax = 5;
	private float maxHeadingChange = 360;
	
	CharacterController controller;
	float heading;
	Vector3 targetRotation;
	Vector3 faceRight = new Vector3(0, 90, 0);
	Vector3 faceLeft = new Vector3(0, -90, 0);

	float edge = 3.21f;
	bool turning = true;

//	bool clockwise = true;
	
	void Awake (){
		controller = GetComponent<CharacterController>();
		
		// Set random initial rotation
		heading = 0;
		targetRotation = faceRight;
		transform.eulerAngles = new Vector3(0, heading, 0);
		
		//StartCoroutine(NewHeading());
	}

	private bool IsWithin(float headY, float degrees, float tarY){
		headY = Mathf.Abs (headY);
		tarY = Mathf.Abs (tarY);
		if (headY - tarY > -degrees && headY - tarY < degrees)
			return true;
		return false;
	}
	
	void Update (){

		// turning
		if (turning) {
			speed = 0;
			if(IsWithin(transform.eulerAngles.y, 5, targetRotation.y)){
				transform.eulerAngles = targetRotation;
				turning = false;
				speed = 1.5f;
			}
		} else {
			if(transform.position.x > edge){
				turning = true;
				targetRotation = faceLeft;
			}else if(transform.position.x < -edge){
				turning = true;
				targetRotation = faceRight;
			}
		}

		transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		var forward = transform.TransformDirection(Vector3.forward);
		controller.SimpleMove(forward * speed);

		// walking
			// meet edge
				// turn
	}
	
	/// <summary>
	/// Repeatedly calculates a new direction to move towards.
	/// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
	/// </summary>
	IEnumerator NewHeading (){
		while (true){
			NewHeadingRoutine();
			directionChangeInterval = Random.Range(-directionChangeIntervalMin, directionChangeIntervalMax);
			yield return new WaitForSeconds(directionChangeInterval);
		}
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