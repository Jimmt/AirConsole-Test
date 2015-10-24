using UnityEngine;
using System.Collections;

public class BlockSpawner : MonoBehaviour
{
	public GameObject block;

	// Use this for initialization
	void Start ()
	{
		for (int i = -5; i < 5; i++) {
			for (int j = 1; j < 6; j++) {
				GameObject temp = Instantiate (block);
				Renderer renderer = temp.GetComponent<Renderer> ();
				float width = renderer.bounds.size.x;
				float height = renderer.bounds.size.y;
				float marginX = 0.0f;
				float marginY = 0.0f;
				temp.transform.position = new Vector3 (transform.position.x + (float)i * width + marginX, transform.position.y - (float)j * height + marginY, 0);
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

	}
}
