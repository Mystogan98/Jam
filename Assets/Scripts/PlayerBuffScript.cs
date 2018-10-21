using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuffScript : MonoBehaviour {

	public bool dash, inv, tempInv;
	public int reducCS, dashDuration, dashVitesse, dureeInv;
	public int trash;

	public void setDash() { dash = true; }
	public void setInv() { inv = true; }
	public void setTempInv() { tempInv = true; }
	public void setReducCS() { reducCS++; }
	public void setDashDuration() { dashDuration++; }
	public void setDashVitesse() { dashVitesse++; }
	public void setDureeInv() { dureeInv++; }
	public void setTrash() { trash++; }

	private void Start() {
		DontDestroyOnLoad(this.gameObject);
	}
}
