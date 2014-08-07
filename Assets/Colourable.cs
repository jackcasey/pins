using UnityEngine;
using System.Collections;

public class Colourable : MonoBehaviour {
	static Color red = 		Color.red;
	static Color blue = 	Color.blue;
	static Color yellow = 	Color.yellow;
	static Color gray = 	Color.gray;

	static Color[] colors = { red, blue, yellow, gray };
	
	public int color;

	// Use this for initialization
	void Start () {
		renderer.material.color = colors[color];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
