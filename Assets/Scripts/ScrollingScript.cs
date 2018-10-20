using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingScript : MonoBehaviour {

	[Tooltip("Base speed of the player")]
	public float speed;
	[Tooltip("Accelaration (multiplicative)")]
	public float accel;

	void FixedUpdate () {
		transform.position += Vector3.right * speed * Time.fixedDeltaTime;

		speed = speed * (1+(accel * Time.fixedDeltaTime));
	}
}
