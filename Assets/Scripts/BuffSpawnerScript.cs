using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawnerScript : MonoBehaviour {

	public List<GameObject> buffCS, DashDuration, DashVitesse, DureeInv, trash;
	public GameObject Dash, Inv, TempInv;
	static public PlayerBuffScript player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("PlayerBuff").GetComponent<PlayerBuffScript>();
		if	(player.dash)
			Dash.SetActive(false);
		if (player.inv)
			Inv.SetActive(false);
		if (player.tempInv)
			TempInv.SetActive(false);
		for(int i = 0 ; i < 10 ; i++)
		{
			if(player.reducCS >= i+1)
				buffCS[i].SetActive(false);
			else	
				break;
		}
		for(int i = 0 ; i < 4 ; i++)
		{
			if(player.dashDuration >= i+1)
				DashDuration[i].SetActive(false);
			if(player.dashVitesse >= i+1)
				DashVitesse[i].SetActive(false);
			if(player.dureeInv >= i+1)
				DureeInv[i].SetActive(false);
		}
		for(int i = 0 ; i < 40 ; i++)
		{
			if(player.trash >= i+1)
				trash[i].SetActive(false);
			else	
				break;
		}
	}
}
