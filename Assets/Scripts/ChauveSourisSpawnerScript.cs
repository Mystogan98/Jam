using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChauveSourisSpawnerScript : MonoBehaviour {

	public float startTimer, baseReloadTime;
	public float randomSpawnTime;
	public GameObject toSpawn;

	private float timer = 0, lastSpawn, reloadTime;

	// Use this for initialization
	void Start () {
		lastSpawn = startTimer;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.fixedDeltaTime;
		if((lastSpawn + reloadTime) < timer)
		{
			lastSpawn = timer;
			Instantiate(toSpawn,transform.position,transform.rotation);
			reloadTime = baseReloadTime * Random.Range(0.2f,randomSpawnTime);
		}	
	}
}
