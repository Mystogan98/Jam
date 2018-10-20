using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayScript : MonoBehaviour {

	public GameObject platform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		Physics2D.IgnoreCollision(GetComponent<Collider2D>(),other.GetComponent<Collider2D>(), true);
	}

	private void OnTriggerExit2D(Collider2D other) {
		Physics2D.IgnoreCollision(GetComponent<Collider2D>(),other.GetComponent<Collider2D>(),false);
	}
}
