using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceText : MonoBehaviour {

	public PlayerController player;
	public Text distance;
	public Image inv, TempInv;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		distance.text = "Distance : " + (int) player.transform.parent.position.x + "m";
		if(player.invincibilityCount > 0)
			inv.enabled = true;
		else
			inv.enabled = false;
		if(player.invincibilityTimer > 0)
			TempInv.enabled = true;
		else	
			TempInv.enabled = false;
	}
}
