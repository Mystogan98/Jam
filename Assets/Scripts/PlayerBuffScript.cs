using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuffScript : MonoBehaviour {

	public bool dash, inv, tempInv;
	public int reducCS, dashDuration, dashVitesse, dureeInv;
	public int trash;
	public float scoreMax;
	public int morts;

	public int skin = 0;


	static public PlayerBuffScript Instance { get { return _instance; } }
	static private PlayerBuffScript _instance;

	public void setDash() { Instance.dash = true; }
	public void setInv() { Instance.inv = true; }
	public void setTempInv() { Instance.tempInv = true; }
	public void setReducCS() { Instance.reducCS++; }
	public void setDashDuration() { Instance.dashDuration++; }
	public void setDashVitesse() { Instance.dashVitesse++; }
	public void setDureeInv() { Instance.dureeInv++; }
	public void setTrash() { Instance.trash++; }

	public void setSkin1() { skin = 1; }
	public void setSkin2() { skin = 2; }
	
	public void ResetSkin() { skin = 0; }


	private void Start() {
		_instance = this;
		DontDestroyOnLoad(this.gameObject);
	}
}
