using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

	[SerializeField]
	private GameObject lampLight;

	[SerializeField]
	private GameObject lampLightSpot;

	[SerializeField]
	private GameObject PossessedModel;

	[SerializeField]
	private GameObject FlyingDemonModel;

	[SerializeField]
	private Light lt;

	[SerializeField]
	private Light lt1;

	[SerializeField]
	private Light lt2;

	public bool flicker = false;
	public float duration = 1.0F;
	private AudioSource laugh;

	void Start() {
		laugh = GetComponent<AudioSource> ();
	}
	             
	void Update () {
		float time1 = Time.timeSinceLevelLoad;
		if (time1 > 4.0f && time1 < 12.0f) {
			//PossessedModel.GetComponent<Animation> ().Play ("walk");
			PossessedModel.transform.Translate (Vector3.up * -Time.deltaTime * 1.2f);
		}
		if (Time.timeSinceLevelLoad >= 4.0f && Time.timeSinceLevelLoad <= 12.0f) {
			if (laugh.isPlaying) {
				goto A;
			} else if (!laugh.isPlaying && time1 < 7.0f)
				laugh.Play ();
		}
		A: {}
		if (time1 >= 5.0f && time1 <= 6.5f) {
			float phi = Time.timeSinceLevelLoad / duration * 2 * Mathf.PI;
			float amplitude = Mathf.Cos (phi);
			if (Mathf.Abs(amplitude) >= (0.5f)) {
				lt.intensity = 2f;
				lt1.intensity = 2f;
				lt2.intensity = 2f;
			} else {
				lt.intensity = 0f;
				lt1.intensity = 0f;
				lt2.intensity = 0f;
			}
		}
		if (time1 < 12.0f && time1 > 7f) {
			lampLight.SetActive(false);
			lampLightSpot.SetActive(false);

		}
			
		if (time1 >= 12.0f && !flicker) {
			lampLight.SetActive(true);
			lampLightSpot.SetActive(true);
			FlyingDemonModel.SetActive(true);
			lt.intensity = 2f;
			lt1.intensity = 2f;
		}
		float randTime2 = Random.Range (10, 12);
		int counter = 0;
		if (((int)Time.timeSinceLevelLoad % (int)randTime2 == 0) && time1 >= 15.0f) {
			flicker = true;
			float phi = Time.timeSinceLevelLoad / duration * 2 * Mathf.PI;
			float amplitude = Mathf.Cos (phi);
			while (counter < 4) {
				if (Mathf.Abs (amplitude) >= (0.5f)) {
					lt.intensity = 4f;
					lt1.intensity = 4f;
					lt2.intensity = 4f;
				} else {
					lt.intensity = 0f;
					lt1.intensity = 0f;
					lt2.intensity = 0f;
				}
				counter++;
			}
			while (counter < 20) {
				lt.intensity = 0f;
				lt1.intensity = 0f;
				lt2.intensity = 0f;
				counter++;
			}
			lt.intensity = 4f;
			lt1.intensity = 4f;
			lt2.intensity = 4f;
			flicker = false;
		} else if (time1 > 15.0f) {
			float phi = Time.timeSinceLevelLoad / duration * 2 * Mathf.PI;
			float amplitude = Mathf.Cos (phi/10);
			lt.intensity = 2f * Mathf.Abs (amplitude);
		}
	}
}
