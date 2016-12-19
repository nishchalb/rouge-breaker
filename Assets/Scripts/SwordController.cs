using UnityEngine;
using System.Collections;

public class SwordController : MonoBehaviour {
	
	public GameObject Sword;
	public float Gain = 10.0f;
	public float maxRotationalVelocity = 1000.0f;
    public Camera camera;
	
	private float secondaryGain;
	private Vector3 target;
	float r;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diffPos = target - GetComponent<Transform>().position;
		
		secondaryGain = (new Vector2(diffPos.x, diffPos.y)).magnitude;
		
		float desiredAngle = Mathf.Atan2(diffPos.y, diffPos.x) * Mathf.Rad2Deg;
		if (desiredAngle < 0) desiredAngle += 360;
		
		float angle = Vector3.Angle(diffPos, Sword.GetComponent<Transform>().eulerAngles);
		
		float currentAngle = Sword.GetComponent<Transform>().eulerAngles.z; // 0 to 360
		// Debug.LogError("current angle is " + currentAngle + " desired is " + desiredAngle);
		r = desiredAngle - currentAngle;
		if (r >= 180) {
			r = desiredAngle - currentAngle - 360;
		}
		else if (r <= -180) {
			r = desiredAngle + 360 - currentAngle;
		}
		// Debug.LogError("r is " + r);
		
	}
	
	void FixedUpdate() {
		// SwordTransform.rotation = Quaternion.LookRotation(Vector3.forward, target - GetComponent<Transform>().position);
		Sword.GetComponent<Rigidbody2D>().angularVelocity = Mathf.Max(Mathf.Min(Gain * r, maxRotationalVelocity), -maxRotationalVelocity);
		// Debug.LogError("angular velocity is " + Sword.GetComponent<Rigidbody2D>().angularVelocity);
		// Sword.GetComponent<RelativeJoint2D>().angularOffset = r*-10;
	}
}
