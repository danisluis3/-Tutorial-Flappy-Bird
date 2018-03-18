using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour {

	public GameObject pipeBottomPrefab, pipeTopPrefab;

	private float initiateXPosition = -8;
	private float startDeleteObstacle = 7;
	private float deltaX = 3;
	private int indexToDelete = 0;
	private GameObject[] obstacleObjectTop, obstacleObjectBottom;

	// Use this for initialization
	void Start () {
		obstacleObjectTop = new GameObject[10];
		obstacleObjectBottom = new GameObject[10];
		GameObject gO;
		//gO = Instantiate (pipeBottomPrefab);
		//gO.transform.Rotate (0, 0, 90);
		for (int i = 0; i < 10; i++) {
			obstacleObjectTop [i] = Instantiate (pipeTopPrefab);
			obstacleObjectBottom [i] = Instantiate (pipeBottomPrefab);
			obstacleObjectTop [i].transform.position = new Vector3 (initiateXPosition, 12.85f, 0);
			obstacleObjectBottom [i].transform.position = new Vector3 (initiateXPosition, -12.71f, 0);
			initiateXPosition += deltaX;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main.transform.position.x >= startDeleteObstacle) {
			Destroy (obstacleObjectTop[indexToDelete]);
			Destroy (obstacleObjectBottom[indexToDelete]);

			obstacleObjectTop [indexToDelete] = Instantiate (pipeTopPrefab);
			obstacleObjectBottom [indexToDelete] = Instantiate (pipeBottomPrefab);
			obstacleObjectTop [indexToDelete].transform.position = new Vector3 (initiateXPosition, 12.85f, 0);
			obstacleObjectBottom [indexToDelete].transform.position = new Vector3 (initiateXPosition, -12.71f, 0);
			initiateXPosition += deltaX;

			indexToDelete++;
			startDeleteObstacle += deltaX;
		}
	}
}
