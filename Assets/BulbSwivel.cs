using UnityEngine;
using System.Collections;

public class BulbSwivel : MonoBehaviour {
	private AudioSource flicker;
	void Start () {
		flicker = GetComponent<AudioSource> ();

	}
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > 11.0f)
			transform.RotateAround (new Vector3(0f,0f,-0.2f), Vector3.up, 2f + 0.1f*Time.timeSinceLevelLoad);
		if (Time.timeSinceLevelLoad >= 5.0f && Time.timeSinceLevelLoad <= 9.0f) {
			if (flicker.isPlaying) {
				goto A;
			} else if (!flicker.isPlaying && Time.timeSinceLevelLoad < 9.0f)
				flicker.Play ();
		}
		A: {}
	}
}
