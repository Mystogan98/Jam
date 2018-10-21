using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancarteScript : MonoBehaviour {

	public List<Sprite> pancartes;

	private SpriteRenderer spr;
	// Use this for initialization
	void Start () {
		spr = GetComponent<SpriteRenderer>();
		spr.sprite = pancartes[Random.Range(0,pancartes.Count-1)];
	}
	
	// Update is called once per frame
	void Update () {

	}
}
