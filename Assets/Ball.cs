using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
  private Flasher flasher;

  void OnTriggerEnter(Collider other)
  {
    if (this.GetComponent<Colourable>().color == other.GetComponent<Colourable>().color)
    {
      Destroy(this.gameObject);
    }
    else
    {
      Destroy(this.gameObject);
      Draggable d = other.GetComponent<Draggable>();
      if (d)
      {
        d.ResetPosition();
      }
      flasher.flash();
    }
  }

  void Awake()
  {
    this.GetComponent<Colourable>().color = Random.Range(0,3);
    flasher = GameObject.FindGameObjectWithTag("redflash").GetComponent<Flasher>();
  }

  void Update()
  {
  }
}

