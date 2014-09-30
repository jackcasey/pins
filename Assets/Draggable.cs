using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour 
{
	
	private Vector3 screenPoint;
	private Vector3 offset;
	private Vector3 initialPosition;
	private bool dragging;
	public bool canDrag = true;
	public float min;
	public float max;
	public int life = 3;
	private int lives = 3;

	void Start()
	{
		initialPosition = transform.position;
	}

	public void SetLife(int l)
	{
		life = l;
		Colourable c = GetComponent<Colourable>();
		c.SetBrightness((life+2.0f)/5.0f);
	}

	public void Hit()
	{
		SetLife(life-1);
		if (life <= 0)
		{
			ResetPosition();
			SetLife (lives);
		}
	}

	public void ResetPosition()
	{
		transform.position = initialPosition;
		dragging = false;
	}
	
	void OnMouseDown()
	{
		if (!canDrag)
			return;

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
		float x = Mathf.Min (curPosition.x, max);
		x = Mathf.Max (x, min);
		curPosition = new Vector3(x, transform.position.y, transform.position.z);
		transform.position = curPosition;
	}

	void OnMouseUp()
	{	
		SetLife (lives);
		dragging = false;
		Control.masterControl.play ();
	}
	
}