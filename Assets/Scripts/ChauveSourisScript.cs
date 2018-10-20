using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChauveSourisScript : MonoBehaviour {

	public float speed, randomFactor;

	public GameObject top, bottom;

	private int sens = -1;
	private float xspeed;

	// Use this for initialization
	void Start () {
		xspeed = (speed/2) * Random.Range(0,2+randomFactor);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(transform.position.y > top.transform.position.y)
			sens = -1;
		else if (transform.position.y < bottom.transform.position.y)
			sens = 1;
		transform.position += Vector3.up * (speed * Random.Range(1,1+randomFactor)) * Time.fixedDeltaTime * sens;

		transform.parent.position -= Vector3.right * xspeed * Time.fixedDeltaTime;
	}
}
