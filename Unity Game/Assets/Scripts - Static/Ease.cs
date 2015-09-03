using UnityEngine;
using System.Collections;

public static class Ease {
	
	public static bool IsPointWithinBounds(Vector3 p, GameObject bounds){
		RectTransform brt = bounds.GetComponent<RectTransform>();
		float halfW = brt.rect.width/2;
		float halfH = brt.rect.height/2;
		
		// DEBUGGING
		Debug.Log ("is " + p + " within " +
		           (bounds.transform.position.x - halfW) + ", " +
		           (bounds.transform.position.x + halfW) + ", " + 
		           (bounds.transform.position.y - halfH) + ", " + 
		           (bounds.transform.position.y + halfH));
		
		if (p.x > bounds.transform.position.x - halfW &&
		    p.x < bounds.transform.position.x + halfW &&
		    p.y > bounds.transform.position.y - halfH &&
		    p.y < bounds.transform.position.y + halfH) {
			return true;
		}
		return false;
	}
}
