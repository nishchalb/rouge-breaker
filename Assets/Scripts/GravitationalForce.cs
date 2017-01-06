using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalForce : MonoBehaviour {

    public Rigidbody2D[] bodies;
    public float gravConstant;

    private Transform tf;

	// Use this for initialization
	void Start () {
        tf = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        foreach (Rigidbody2D body in bodies)
        {
            Vector2 tfPos = new Vector2(tf.position.x, tf.position.y);
            float distance = Vector2.Distance(body.position, tfPos);
            float forceMag = gravConstant * body.mass / (distance * 1);
            Vector2 direction = tfPos - body.position;
            Vector2 force = direction.normalized * forceMag;
            body.AddForce(force * Time.deltaTime);
        }
    }
}
