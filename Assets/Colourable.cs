using UnityEngine;
using System.Collections;

public class Colourable : MonoBehaviour {
	static Color red = 		new Color(1.0f, 0.4f, 0.4f);
	static Color blue = 	new Color(0.4f, 0.4f, 1.0f);
	static Color yellow = 	new Color(1.0f, 1.3f, 0.4f);
	static Color gray = 	new Color(0.7f, 0.7f, 0.7f);
	static Color black =    Color.black;

	static Color[] colors = { red, blue, yellow, gray, black };
	
	public int color;

	// Use this for initialization
	void Start () {
		renderer.material.color = colors[color];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
