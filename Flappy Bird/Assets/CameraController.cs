using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform targetBird;
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (targetBird.position.x,0,-10);
	}
}
