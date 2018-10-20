using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawnerScript : MonoBehaviour {

	public List<GameObject> levels;
	public GameObject spawnTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.CompareTag("end"))
			Instantiate(levels[Random.Range(0,levels.Count)],spawnTransform.transform.position,spawnTransform.transform.rotation);
	}
}
