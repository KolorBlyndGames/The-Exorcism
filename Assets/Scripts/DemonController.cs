using UnityEngine;
using System.Collections;

public class DemonController : MonoBehaviour {
	public GameObject enemy;   
	private GameObject enemyObj;

	public float spawnTime = 3f;            
	public Transform[] spawnPoints;         

	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn () {	
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		enemyObj = (GameObject)Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
		Destroy (enemyObj, spawnTime);
	}
}