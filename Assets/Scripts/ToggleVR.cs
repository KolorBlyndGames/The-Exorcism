using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ToggleVR : MonoBehaviour {

	public void ToggleVRMode() {
		AutoFade.LoadLevel(1 , 2, 3, Color.black);;
	}

	public void ToggleARMode() {
		AutoFade.LoadLevel(2 , 2, 3, Color.black);;
	}
}
