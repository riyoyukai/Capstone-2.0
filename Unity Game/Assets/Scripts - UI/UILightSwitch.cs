using UnityEngine;
using System.Collections;

public class UILightSwitch : MonoBehaviour {

	public MeshRenderer meshRenderer;
	public Material dayMat;
	public Material nightMat;
	public Light light;

	public GameObject switchOn;
	public GameObject switchOff;

	private bool on = true;

	void OnMouseUp(){
		if(on){ // turn light off
			meshRenderer.material = nightMat;
			light.intensity = .3f;
		}else{
			meshRenderer.material = dayMat;
			light.intensity = 1;
		} // turn light on

		on = !on;
		switchOn.SetActive(!switchOn.activeSelf);
		switchOff.SetActive(!switchOff.activeSelf);
	}
}
