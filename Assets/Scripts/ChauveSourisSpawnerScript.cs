using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChauveSourisSpawnerScript : MonoBehaviour {

	public float startTimer, baseReloadTime;
	public float randomSpawnTime;
	public GameObject toSpawn;

	static public PlayerBuffScript player;

	private float timer = 0, lastSpawn, reloadTime;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("PlayerBuff").GetComponent<PlayerBuffScript>();
		baseReloadTime += (baseReloadTime/10) * player.reducCS;
		lastSpawn = startTimer;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.fixedDeltaTime;
		if((lastSpawn + reloadTime) < timer)
		{
			lastSpawn = timer;
			Instantiate(toSpawn,transform.position,transform.rotation);
			reloadTime = baseReloadTime * Random.Range(0.5f,randomSpawnTime);
		}	
	}
}
