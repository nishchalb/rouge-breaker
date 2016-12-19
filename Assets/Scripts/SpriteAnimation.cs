using UnityEngine;
using System.Collections;

public class SpriteAnimation : MonoBehaviour {
	
	public Transform Ball;
	public float BallLookDistanceThreshold = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float ballDist = (GetComponent<Transform>().position - Ball.position).magnitude;
		if (ballDist < BallLookDistanceThreshold) {
			float ballX = Ball.position.x;
			if (GetComponent<Transform>().position.x <= ballX) GetComponent<Transform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);
			else if (GetComponent<Transform>().position.x > ballX) GetComponent<Transform>().localScale = new Vector3(-1.0f, 1.0f, 1.0f);
		} else {
			// float xScale = Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x);
			float h = Mathf.Sign(Input.GetAxis("Horizontal"));
			GetComponent<Transform>().localScale = new Vector3(h, 1.0f, 1.0f);
		}

	}
}
