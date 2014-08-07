using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour 
{
	
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 initialPosition;
	private bool dragging;
	void Start()
	{
		initialPosition = transform.position;
	}

	public void ResetPosition()
	{
		transform.position = initialPosition;
		dragging = false;
	}
	
	void OnMouseDown()
	{
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		dragging = true;
	}
	
	void OnMouseDrag()
	{
		if (!dragging)
			return;
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
		curPosition = new Vector3(curPosition.x, transform.position.y, transform.position.z);
		transform.position = curPosition;
	}

	void OnMouseUp()
	{
		dragging = false;
	}
	
}