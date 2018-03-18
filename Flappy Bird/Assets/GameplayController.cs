using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour {

	public GameObject pipeBottomPrefab, pipeTopPrefab, skyPrefab, groundPrefab;

	private float initiateXPosition = -8;
	private float startDeleteObstacle = 7;
	private float deltaX = 3;
	private int indexToDelete = 0;

	private float initiateXPositionSky = -10.24f;
	private float startDeleteObstacleSky = 4.64f;
	private float deltaXSky = 10.24f;
	private int indexToDeleteSky = 0;

	private GameObject[] a_obstacleObjectTop, a_obstacleObjectBottom, a_groundObject, a_skyObject;

	// Use this for initialization
	void Start () {
		// init pipes
		a_obstacleObjectTop = new GameObject[10];
		a_obstacleObjectBottom = new GameObject[10];
		for (int i = 0; i < 10; i++) {
			InitializeObject (a_obstacleObjectTop, pipeTopPrefab, initiateXPosition, 12.85f, i);
			InitializeObject (a_obstacleObjectBottom, pipeBottomPrefab, initiateXPosition, -12.71f, i);
			initiateXPosition += deltaX;
		}


		//init sky & ground
		// using hand and determine number of groundobject to release and update\

		// Explain definition "Unit" in Android
		/**
		 *  512pixel => (1 unit <=> 50 pixel) =>> 10.24
		 */

		a_groundObject = new GameObject[3];
		a_skyObject = new GameObject[3];
		for (int i = 0; i < 3; i++) {
			InitializeObject (a_skyObject, skyPrefab, initiateXPositionSky, 5.62f, i);
			InitializeObject (a_groundObject, groundPrefab, initiateXPositionSky, -5.4f, i);
			initiateXPositionSky += deltaXSky;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main.transform.position.x >= startDeleteObstacle) {
			Destroy (a_obstacleObjectTop[indexToDelete]);
			Destroy (a_obstacleObjectBottom[indexToDelete]);

			a_obstacleObjectTop [indexToDelete] = Instantiate (pipeTopPrefab);
			a_obstacleObjectBottom [indexToDelete] = Instantiate (pipeBottomPrefab);
			a_obstacleObjectTop [indexToDelete].transform.position = new Vector3 (initiateXPosition, 12.85f, 0);
			a_obstacleObjectBottom [indexToDelete].transform.position = new Vector3 (initiateXPosition, -12.71f, 0);
			initiateXPosition += deltaX;

			indexToDelete++;
			if (indexToDelete == 10)
				indexToDelete = 0;
			startDeleteObstacle += deltaX;
		}

		if (Camera.main.transform.position.x >= startDeleteObstacleSky) {
			Destroy (a_skyObject[indexToDeleteSky]);
			Destroy (a_groundObject[indexToDeleteSky]);

			a_skyObject [indexToDeleteSky] = Instantiate (skyPrefab);
			a_groundObject [indexToDeleteSky] = Instantiate (groundPrefab);
			a_skyObject [indexToDeleteSky].transform.position = new Vector3 (initiateXPositionSky, 5.62f, 0);
			a_groundObject [indexToDeleteSky].transform.position = new Vector3 (initiateXPositionSky, -5.4f, 0);
			initiateXPositionSky += deltaXSky;

			indexToDeleteSky++;
			if (indexToDeleteSky == 3)
				indexToDeleteSky = 0;
			startDeleteObstacleSky += deltaXSky;
		}
	}

	void InitializeObject(GameObject[] objectArray, GameObject prefab, float localXPosition, float localY, int localIndex) {
		objectArray [localIndex] = Instantiate (prefab);
		objectArray [localIndex].transform.position = new Vector3 (localXPosition, localY, 0);
	}

}
