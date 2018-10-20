using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject player;
	private float offset;

	// Use this for initialization
	void Start () {
		offset = transform.position.x - player.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(player.transform.position.x + offset,transform.position.y,-10);
	}
}
