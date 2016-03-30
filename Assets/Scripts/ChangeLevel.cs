using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ChangeLevel : MonoBehaviour {
	[SerializeField]
	private int index;
	// Update is called once per frame
	void Update () {
		AutoFade.LoadLevel(index , 2, 3, Color.black);
	}
}
