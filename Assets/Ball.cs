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
      flasher.flash();
      Draggable d = other.GetComponent<Draggable>();
      if (d)
      {
        Destroy(other.gameObject);
      }
      else
      {
        Destroy(this.gameObject);
      }
    }
  }

  void Awake()
  {
    this.GetComponent<Colourable>().color = Random.Range(0,3);
    flasher = GameObject.FindGameObjectWithTag("redflash").GetComponent<Flasher>();
  }
}
