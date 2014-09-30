using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	private float duration = 1f;
	private float speedup = 0.0f;
	private float timeScale = 1.5f;
	public static Control masterControl;

	// Use this for initialization
	void Start () {
		masterControl = this;
		play ();
	}

	public void play() {
		Time.timeScale = timeScale;
		timeScale += speedup;
		// prevent all dragging
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player"))
		{
			Draggable d = go.GetComponent<Draggable>();
			d.canDrag = false;
		}

		// pause after duration seconds
		StartCoroutine(WaitAndStop());
	}

	IEnumerator WaitAndStop() {
		yield return new WaitForSeconds(duration);
		duration = 0.5f;
		stop ();
	}

	public void stop() {
		Time.timeScale = 0.0f;
		// enable all dragging
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player"))
		{
			Draggable d = go.GetComponent<Draggable>();
			d.canDrag = true;
		}
	}
	
	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit(); 
	}
}
