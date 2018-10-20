using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour {

	private new SpriteRenderer renderer;

	private void Start() {
		renderer = GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag("MainCamera"))
			Instantiate(gameObject,transform.position + Vector3.right * Mathf.Clamp(renderer.size.x,1,Mathf.Infinity) * transform.localScale.x, transform.rotation);
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.CompareTag("MainCamera"))
			Destroy(gameObject);
	}
}
