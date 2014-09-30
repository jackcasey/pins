using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

public class Draggable : MonoBehaviour
{
  private Vector3 screenPoint;
  private Vector3 offset;
  private Vector3 initialPosition;
  private bool dragging;
  public float min;
  public float max;

  void Start()
  {
    initialPosition = transform.position;
  }

  public void ResetPosition()
  {
    transform.position = initialPosition;
    dragging = false;
  }

  private void OnEnable()
  {
    GetComponent<PanGesture>().PanStarted += handlePanStarted;
    GetComponent<PanGesture>().Panned += handlePanned;
    GetComponent<PanGesture>().PanCompleted += handlePanCompleted;
  }

  private void OnDisable()
  {
    GetComponent<PanGesture>().PanStarted -= handlePanStarted;
    GetComponent<PanGesture>().Panned -= handlePanned;
    GetComponent<PanGesture>().PanCompleted -= handlePanCompleted;
  }

  private void handlePanStarted(object sender, System.EventArgs e)
  {
    screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    dragging = true;
  }

  private void handlePanned(object sender, System.EventArgs e)
  {
    if (!dragging)
    {
      return;
    }
    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
    float x = Mathf.Min (curPosition.x, max);
    x = Mathf.Max (x, min);
    curPosition = new Vector3(x, transform.position.y, transform.position.z);
    transform.position = curPosition;
  }

  private void handlePanCompleted(object sender, System.EventArgs e)
  {
    dragging = false;
  }
}
