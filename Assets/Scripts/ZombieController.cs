using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	[SerializeField]
	private float move_speed;

	[SerializeField]
	private Transform player;

	void Start() {
		
	}
	void Update () {
		Vector3 targetPosition = new Vector3 (player.position.x,this.transform.position.y,player.position.z);
		this.transform.LookAt (targetPosition);
		Vector3 oldPos = new Vector3 (transform.position.x, 0f, transform.position.z);
		transform.position = oldPos; 
		transform.Translate (Vector3.forward * Time.deltaTime);
		//this.GetComponent<Animation> ().Stop ("attack");
		this.GetComponent<Animation> ().CrossFade ("walk");
	}

	void AttackPlayer () {
		this.GetComponent<Animation> ().Stop ("walk");
		this.GetComponent<Animation> ().CrossFade ("attack");
	}
}
