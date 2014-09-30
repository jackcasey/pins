using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour
{
  void Start()
  {
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      Application.Quit();
    }
  }
}
