// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour {
  [SerializeField]
  private GameObject gameWinImage;

	[SerializeField]
	private GameObject player;

	[SerializeField]
	private GameObject demon;

	[SerializeField]
	private GameObject demonModel;

  private Vector3 startingPosition;      
  public Transform[] spawnPoints;  
  public int score = 0;
  public int levelIndex = 1;
  public bool holyWater = true;
  public float holyWaterStart = 0f; 
  public float coolDownTime = 3f;
  public int numOfTries = 5;

  void Start() {
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		transform.position = (spawnPoints[spawnPointIndex].position);
        startingPosition = transform.localPosition;
        SetGazedAt(false);
		demonModel.SetActive (false);
  }


  void FixedTimeBeforeTeleport(int levelIndex) {
		if (Time.timeSinceLevelLoad - (int)Time.timeSinceLevelLoad <= 0.04f) {
			if ((int)Time.timeSinceLevelLoad % (int)(7 / (levelIndex * 0.5f)) == 0) {
				TeleportRandomly ();
			}
			if ((int)Time.timeSinceLevelLoad % (int)(10 / (levelIndex * 0.5f)) == 0) {
				demonModel.transform.position = new Vector3 (0.1f, 0f, 5f);
				demonModel.SetActive (true);
				int counter = 0;
				demonModel.GetComponent<Animation> ().Play ("attack");
				player.SendMessage("ApplyDamage", 5.0f, SendMessageOptions.DontRequireReceiver);
			}
			if (!demonModel.GetComponent<Animation> ().isPlaying)
				demonModel.SetActive (false);
		}
  }
  void Update() {
		if(Cardboard.SDK.Triggered) {
			numOfTries -= 1;
			if (numOfTries == 0) {
				if (score >= 15) {
					gameWinImage.SetActive (true);
					demon.SetActive (false);
					gameObject.SetActive (false);
				}
				else if (score != 1 || score != 3 || score != 6 || score != 10 || score != 15) {

				}
			}
			if (score == 1) {
				levelIndex++;
				numOfTries = 5;
			} else if (score == 3) {
				levelIndex++;
				numOfTries = 5;
			} else if (score == 6) {
				levelIndex++;
				numOfTries = 5;
			} else if (score == 10) {
				levelIndex++;
				numOfTries = 5;
			} else if (score == 15) {
				levelIndex++;
				numOfTries = 5;
			} 
		}
		FixedTimeBeforeTeleport (levelIndex);

  }

  void LateUpdate() {
    Cardboard.SDK.UpdateState();
    if (Cardboard.SDK.BackButtonPressed) {
      Application.Quit();
    }
  }

  public void SetGazedAt(bool gazedAt) {
    GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
  }

  public void Reset() {
    transform.localPosition = startingPosition;
  }

  public void ToggleVRMode() {
    Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
  }

  public void TeleportRandomly() {
	int spawnPointIndex = Random.Range (0, spawnPoints.Length);
    transform.localPosition = spawnPoints[spawnPointIndex].position;

	/*
    Vector3 direction = Random.onUnitSphere;
    direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
    float distance = 2 * Random.value + 1.5f;
    */
  }

  public void DemonHit() {
	score += 1;
	TeleportRandomly ();
  }
}
