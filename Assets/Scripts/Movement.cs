using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	[HideInInspector] public bool jump = false;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	public Vector2 speed = new Vector2(50, 50);
	
	private Vector2 movement;
	private bool grounded = false;
	private Rigidbody2D rb;

	void Awake () {
		rb = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		
		if (Input.GetKeyDown(KeyCode.Space) && grounded) {
			jump = true;
		}
		
	}
	
	void FixedUpdate() {
        if (grounded)
        {
            rb.drag = 10.0f;
        } else
        {
            rb.drag = 1.0f;
        }

		float h = Input.GetAxis("Horizontal");
		if (h * rb.velocity.x < maxSpeed) {
			rb.AddForce(Vector2.right * h * moveForce);
		}
		
		if (Mathf.Abs(rb.velocity.x) > maxSpeed) {
			rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
		}
		
		if (jump) {
			rb.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
		
	}
}
