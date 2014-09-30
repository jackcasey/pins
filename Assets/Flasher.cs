using UnityEngine;
using System.Collections;

public class Flasher : MonoBehaviour
{
  void Start()
  {
    setAlpha(0.0f);
  }

  void Update()
  {
    setAlpha(Mathf.Lerp(guiTexture.color.a, 0, Time.deltaTime*6));
  }

  public void flash()
  {
    setAlpha(0.8f);
  }

  void setAlpha(float alpha)
  {
    guiTexture.color = new Color(guiTexture.color.r, guiTexture.color.g, guiTexture.color.b, alpha);
  }
}
