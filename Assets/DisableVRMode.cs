using UnityEngine;
using System.Collections;

public class DisableVRMode : MonoBehaviour {

	void Start () {
		Cardboard.SDK.VRModeEnabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
