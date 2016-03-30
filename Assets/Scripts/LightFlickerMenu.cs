using UnityEngine;
using System.Collections;

public class LightFlickerMenu : MonoBehaviour {

	[SerializeField]
	private GameObject lampLight;

	[SerializeField]
	private Light lt;

	public float duration = 1.0F;
	             
	void Update () {
		float time1 = Time.timeSinceLevelLoad;

		if (time1 >= 2.0f && time1 <= 4f) {
			/*
			lampLight.SetActive(false);
			wallLight.SetActive(false);
			wallLight1.SetActive (false);
			lampLightSpot.SetActive(false);
			*/
			float phi = Time.timeSinceLevelLoad / duration * 3 * Mathf.PI;
			float amplitude = Mathf.Cos (phi);
			if (Mathf.Abs(amplitude) >= (0.5f)) {
				lt.intensity = 2f;
			} else {
				lt.intensity = 0f;
			}
			/*
			if (time1 % 2 > 0.045) {
				lampLight.SetActive(false);
				lampLightSpot.SetActive(false);
				wallLight.SetActive(false);
			} else {
				lampLight.SetActive (true);
				wallLight.SetActive (true);
				lampLightSpot.SetActive (true);
			} 
			*/
		}

			
		if (time1 >= 4.0f) {
			lampLight.SetActive(true);
			lt.intensity = 3.2f;
		}
	}
}
