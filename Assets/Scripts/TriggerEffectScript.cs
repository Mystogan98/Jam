using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEffectScript : MonoBehaviour {

	static private PlayerController player;

	private void Start() {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	public void Die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	} 

	public void Invincibility()
	{
		Debug.Log("Not yet implemented");
	}

	public void TempInvincibility()
	{
		Debug.Log("Not yet implemented");
	}

	public void Dash(){
		Debug.Log("Not yet implemented");
	}

	public void Inverser() {
		player.reversed = !player.reversed;
	}
}
