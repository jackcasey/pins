using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float spawnTime;
	public float minX;
	public float maxX;
	public float setY;
	public float setZ;
	public GameObject spawn;


	// Use this for initialization
	void Start () {
		StartCoroutine( Spawnit() );
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Spawnit()
	{
		while( true )
		{
			Instantiate(spawn, new Vector3(Random.Range (minX, maxX), setY, setZ), new Quaternion());
			yield return new WaitForSeconds( spawnTime );
		}
	}

}
