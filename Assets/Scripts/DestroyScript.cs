using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.CompareTag("MainCamera"))	
			Destroy(gameObject);
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.CompareTag("MainCamera"))
			Destroy(gameObject);
	}
}
