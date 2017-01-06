using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float HP = 100.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<SpriteRenderer>().color = new Color(0.0f, HP/100.0f, 0.0f);
		//Debug.LogError("hp is " + HP);
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		// Debug.LogError("vel of collision is " + collision.relativeVelocity);
		if (collision.gameObject.tag == "Ball" && collision.relativeVelocity.magnitude > 10) {
			HP -= 2 * collision.relativeVelocity.magnitude;
		}
	}
}
