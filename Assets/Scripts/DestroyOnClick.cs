using UnityEngine;
using System.Collections;

public class DestroyOnClick : MonoBehaviour {
	
	void OnClick() {
		Destroy (gameObject);
		Debug.Log ("Ha bhai");
	}
}
