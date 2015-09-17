using UnityEngine;
using System.Collections;

/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// from http://wiki.unity3d.com/index.php/Wander
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class Wander : MonoBehaviour
{

	enum FacingDirection {
		Left,
		Right
	}

	private FacingDirection dir = FacingDirection.Left;
	private float speed = 2;
	private float directionChangeInterval = 1;
	private float directionChangeIntervalMin = 1;
	private float directionChangeIntervalMax = 5;
	private float maxHeadingChange = 60;
	
	CharacterController controller;
	float heading;
	Vector3 targetRotation;
	
	void Awake (){
		controller = GetComponent<CharacterController>();
		
		// Set random initial rotation
		heading = 90;
		//transform.eulerAngles = new Vector3(0, heading, 0);
		
		StartCoroutine(NewHeading());
	}
	
	void Update (){
		//transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		var forward = transform.TransformDirection(Vector3.forward);
		//controller.SimpleMove(forward * speed);

		if (dir == FacingDirection.Left) {

			print (heading);

			if(heading != 270){
				heading = Mathf.Lerp(heading, 270, Time.deltaTime * directionChangeInterval);
				if(Mathf.Abs(heading - 270) < 1) {
					heading = 270;
					transform.rotation = Quaternion.LookRotation(Vector3.left);
				}

			} else {
				controller.SimpleMove(forward * speed);
			}

		} else {
			if(heading != 90){
				heading = Mathf.Lerp(heading, 90, Time.deltaTime * directionChangeInterval);
				if(Mathf.Abs(heading - 90) < 1) {
					heading = 90;
					transform.rotation = Quaternion.LookRotation(Vector3.right);
				}
			} else {
				controller.SimpleMove(forward * speed);
			}

		}

	}
	
	/// <summary>
	/// Repeatedly calculates a new direction to move towards.
	/// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
	/// </summary>
	IEnumerator NewHeading (){
		while (true){
			NewHeadingRoutine();
			directionChangeInterval = Random.Range(directionChangeIntervalMin, directionChangeIntervalMax);
			yield return new WaitForSeconds(directionChangeInterval);
		}
	}
	
	/// <summary>
	/// Calculates a new direction to move towards.
	/// </summary>
	void NewHeadingRoutine (){

		if (Random.Range (0, 100) > 50) {
			dir = FacingDirection.Left;
		} else {
			dir = FacingDirection.Right;
		}
	}
}