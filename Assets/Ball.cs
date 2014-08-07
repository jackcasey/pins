using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Flasher flasher;


	void OnTriggerEnter(Collider other) {
		if (this.GetComponent<Colourable>().color == other.GetComponent<Colourable>().color)
		{
			Destroy(this.gameObject);
		} 
		else 
		{
			flasher.flash();
		}
	}


	// Use this for initialization
	void Start () {
		flasher = GameObject.FindGameObjectWithTag("redflash").GetComponent<Flasher>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
}
