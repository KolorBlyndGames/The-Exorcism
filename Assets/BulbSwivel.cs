using UnityEngine;
using System.Collections;

public class BulbSwivel : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > 11.0f)
			transform.RotateAround (new Vector3(0f,0f,-0.2f), Vector3.up, 2f + 0.05f*Time.timeSinceLevelLoad);
	}
}
