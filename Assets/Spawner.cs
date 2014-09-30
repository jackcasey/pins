using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	private float spawnTime = 0.75f;
	public float minX;
	public float maxX;
	public float setY;
	public float setZ;
	public GameObject spawn;
	public float speed = 1.0f;


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
			GameObject go = Instantiate(spawn, new Vector3(Random.Range (minX, maxX), setY, setZ), new Quaternion()) as GameObject;
			Ball b = go.GetComponent<Ball>();
			b.Push(speed);
			yield return new WaitForSeconds( spawnTime );
			spawnTime *= 0.98f;
		}
	}

}
