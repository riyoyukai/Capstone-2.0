using UnityEngine;
using System.Collections;

public static class Ease {
	
	public static bool IsPointWithinRect(Vector3 p, GameObject rect){
		RectTransform brt = rect.GetComponent<RectTransform>();
		float halfW = brt.rect.width/2;
		float halfH = brt.rect.height/2;
		
		// DEBUGGING
//		Debug.Log ("is " + p + " within " +
//		           (rect.transform.position.x - halfW) + ", " +
//		           (rect.transform.position.x + halfW) + ", " + 
//		           (rect.transform.position.y - halfH) + ", " + 
//		           (rect.transform.position.y + halfH));
		
		if (p.x > rect.transform.position.x - halfW &&
		    p.x < rect.transform.position.x + halfW &&
		    p.y > rect.transform.position.y - halfH &&
		    p.y < rect.transform.position.y + halfH) {
			return true;
		}
		return false;
	}
	
	public static bool IsPointWithinSprite(Vector3 p, SpriteRenderer sprite){
		Bounds b = sprite.bounds;
		float halfW = b.extents.x/2;
		float halfH = b.extents.y/2;
		
		// DEBUGGING
		Debug.Log ("is " + p + " within " +
	           (b.center.x - halfW) + ", " +
		           (b.center.x + halfW) + ", " + 
		           (b.center.y - halfH) + ", " + 
		           (b.center.y + halfH));
		
		if (p.x > b.center.x - halfW &&
		    p.x < b.center.x + halfW &&
		    p.y > b.center.y - halfH &&
		    p.y < b.center.y + halfH) {
			return true;
		}
		return false;
	}
}
