using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour {

    public Rigidbody2D Player;
    public float gravityScaler;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator slowDown(float seconds)
    {
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        Player.gravityScale /= gravityScaler;
        yield return new WaitForSeconds(seconds);
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02F;
        Player.gravityScale *= gravityScaler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(slowDown(0.3f));
    }
}
