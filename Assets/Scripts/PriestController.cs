using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PriestController : MonoBehaviour {
	public float healthPacket = 100.0f;
	[SerializeField]
	private GameObject image;
	[SerializeField]
	private GameObject image1;
	[SerializeField]
	private int sceneIndex;

	void ApplyDamage(float Damage) {
		healthPacket -= Damage;
	}

	void Update () {
		if (healthPacket == 0.0f) {
			image.SetActive (true);
			image1.SetActive (false);
			int counter = 0;
			while (counter < 100) {
				counter++;
			}
			SceneManager.LoadScene (sceneIndex);
		}
	}
}
