using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour
{
	public GameObject leftWall, rightWall;
	public GameObject ball;
	private BallController ballController;
	private Vector3 velocity, ballPosition;
	float vx = 0.1f;
	float width, height, wallWidth;

	// Use this for initialization
	void Start ()
	{
		//body = gameObject.GetComponent<Rigidbody2D> ();
		Renderer renderer = gameObject.GetComponent<Renderer> ();
		width = renderer.bounds.size.x;
		height = renderer.bounds.size.y;
		velocity = new Vector3 (vx, 0, 0);

		Renderer wallRenderer = rightWall.GetComponent<Renderer> ();
		wallWidth = rightWall.transform.localScale.x * wallRenderer.bounds.size.x;
		ballController = ball.GetComponent<BallController> ();

		ballPosition = new Vector3 ();
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space) && !ballController.launched) {
			ballController.launch ();
		}
		if (!ballController.launched) {
			ballPosition.Set (transform.position.x, transform.position.y + height, 0);
			ball.transform.position = ballPosition;
		}
	}
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetKey (KeyCode.D) && gameObject.transform.position.x + width / 2 < rightWall.transform.position.x - wallWidth / 2 - vx) {
			velocity.x = vx;
			transform.Translate (velocity);
		}
		if (Input.GetKey (KeyCode.A) && gameObject.transform.position.x - width / 2 > leftWall.transform.position.x + wallWidth / 2 + vx) {
			velocity.x = -vx;
			transform.Translate (velocity);
		}
	}
}
