using UnityEngine;
using System.Collections;

/// <summary>
/// from http://forum.unity3d.com/threads/animal-ai-random-movements.304868/
/// by http://forum.unity3d.com/members/lineupthesky.762934/
/// </summary>
public class Wander2 : MonoBehaviour {

	public float speed;
	public float randomX;
	public float randomZ;
	public float minWaitTime;
	public float maxWaitTime;
	private Vector3 currentRandomPos;
		
	void Start(){
		PickPosition();
	}
	
	void PickPosition(){
		currentRandomPos = new Vector3(Random.Range(-randomX, randomX), 0, Random.Range(-randomZ, randomZ));
		StartCoroutine ( MoveToRandomPos());
		print ("Picking new position: " + currentRandomPos.x + ", " + currentRandomPos.z);
	}

	void update(){
		//print ();
	}
           
	IEnumerator MoveToRandomPos(){
		float i = 0.0f;
		float rate = 1.0f / speed;
		Vector3 currentPos = transform.position;

		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			transform.position = Vector3.Lerp (currentPos, currentRandomPos, i);
			yield return null;
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
}
