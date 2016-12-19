using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public GameObject Ball;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire2") && !Ball.GetComponent<Renderer>().isVisible) {
			Ball.GetComponent<Transform>().position = GetComponent<Transform>().position + 3 * Vector3.up;
			Ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}
	}
}
