using UnityEngine;
using System.Collections;

public class WanderNoCC : MonoBehaviour {

	private Vector3 target = new Vector3(0, 0, -10);
	
	enum FacingDirection {
		Left,
		Right
	}
	private FacingDirection dir = FacingDirection.Left;

	private void PickNewPoint(){

		int r = Ease.RandomInt (1, 3);
		if (r == 1) {
			// first floor
			target.y = 1;
		} else if (r == 2) {
			// second floor
			target.y = 2;
		} else { // r == 3
			// third floor
			target.y = 3;
		}

		target.x = Ease.RandomFloat (-6, 6);
	}

	private void GoToPoint(){

	}
}
