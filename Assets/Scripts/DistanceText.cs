using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceText : MonoBehaviour {

	public PlayerController player;
	public Text distance, morts, distanceMax;
	public Image inv, TempInv;
	public PlayerBuffScript playerBuff;

	// Use this for initialization
	void Start () {
		playerBuff = PlayerBuffScript.Instance;
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
		distanceMax.text = "Distance max : " + (int) playerBuff.scoreMax + "m";
		morts.text = "Morts : " + playerBuff.morts; 
	}
}
