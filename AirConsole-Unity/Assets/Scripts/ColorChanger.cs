using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorChanger : MonoBehaviour
{
	SpriteRenderer background;
	Button startButton;
	Color[] colorCycle;
	Color lastColor;
	int index = 0;
	float time = 0f, interpTime = 5f;

	// Use this for initialization
	void Start ()
	{
		startButton = gameObject.transform.Find ("start_button").GetComponent<Button> ();
		background = GameObject.Find ("uibackground").GetComponent<SpriteRenderer> ();
		Color temp = background.color;
		colorCycle = new Color[] {
			background.color,
			new Color (37 / 255f, 161 / 255f, 154 / 255f),
			new Color (37 / 255f, 78 / 255f, 161 / 255f),
			new Color (71 / 255f, 37 / 255f, 161 / 255f),
			new Color (161 / 255f, 37 / 255f, 133 / 255f),
			new Color (161 / 255f, 37 / 255f, 37 / 255f),
			new Color (161 / 255f, 106 / 255f, 37 / 255f),
			new Color (161 / 255f, 140 / 255f, 37 / 255f)
			};

		for (int i = 1; i < colorCycle.Length; i++) {
			colorCycle[i] = brighten(colorCycle[i], 10/255f);
		}
	}

	Color brighten (Color color, float offset)
	{
		return new Color (color.r + offset, color.g + offset, color.b + offset);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (background.color == colorCycle [index]) {
			lastColor = background.color;  
			time = 0;
			if (index < colorCycle.Length - 1) {
				index++;
			} else {
				index = 0;
			}
		} else {
			background.color = Color.Lerp (lastColor, colorCycle [index], time);
		}
		if (time < 1) {
			time += Time.deltaTime / interpTime;
		}
		
	}
}
