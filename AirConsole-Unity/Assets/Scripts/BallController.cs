using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallController : MonoBehaviour
{
	public bool launched = false;
	public Text scoreLabel;
	private Rigidbody2D body;
	private Vector2 adjustForce;
	int score;
	// Use this for initialization
	void Start ()
	{
		body = gameObject.GetComponent<Rigidbody2D> ();
		adjustForce = new Vector2 (0, 0.25f);
	}

	public void launch ()
	{
		launched = true;
		float angle = Mathf.PI / 2 + (Random.value - 0.5f > 0 ? Random.value * Mathf.PI / 3 : -Random.value * Mathf.PI / 3);
		//angle = 0f;
		float magnitude = 250;
		float vx = Mathf.Cos (angle) * magnitude;
		float vy = Mathf.Sin (angle) * magnitude;
		body.AddForce (new Vector2 (vx, vy));
	}

	void FixedUpdate ()
	{
		if (Mathf.Abs (body.velocity.y) < 1) {
			body.AddForce (adjustForce);
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.layer == 9) { //block
			score += 10;
			scoreLabel.text = "SCORE" + score;
			Destroy (col.gameObject);
		} else if (col.gameObject.tag == "wall_side") {

		} else if (col.gameObject.tag == "wall_top") {

		} else if (col.gameObject.tag == "paddle") {

		}

	}
}
