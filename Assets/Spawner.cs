using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
  public float spawnTime;
  public float minX;
  public float maxX;
  public float setY;
  public float setZ;
  public GameObject spawn;

  void Start()
  {
    StartCoroutine(Spawnit());
  }

  IEnumerator Spawnit()
  {
    while (true)
    {
      Instantiate(spawn, new Vector3(Random.Range (minX, maxX), setY, setZ), new Quaternion());
      yield return new WaitForSeconds(spawnTime);
    }
  }
}
