using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ChangeLevel : MonoBehaviour {
	[SerializeField]
	private int index;
	// Update is called once per frame
	void Update () {
		if (index != 3)
			AutoFade.LoadLevel (index, 2, 3, Color.black);
		else
			SceneManager.LoadScene (3);
	}
}
