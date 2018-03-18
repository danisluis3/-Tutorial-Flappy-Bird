using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	public float gravityPower;
	public float speed = 5;
	public float jumpPower = 6;
	public float velocityCap = 10f;
	private Vector3 velocity;

	private bool outOfControl = false;

	// Use this for initialization
	void Start () {
		velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		// sX = t*v;
		// sY = 0.5*-g*t^2
		if (this.transform.position.y < -20)
			this.enabled = false;
		velocity.x = speed;
		velocity.y += 0.5f * -gravityPower * Time.deltaTime;

		// jump
		if (!outOfControl&Input.GetMouseButtonDown(0))
			velocity.y = jumpPower;

		this.transform.rotation = Quaternion.Euler(0,0,90*Mathf.Clamp(velocity.y/velocityCap,-1,1));
		this.transform.position += velocity*Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		outOfControl = true;
		velocity = Vector3.zero;
	}
}
