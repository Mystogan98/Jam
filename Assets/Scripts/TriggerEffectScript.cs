using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEffectScript : MonoBehaviour {

	public float InvincibilityTimer = 3, dashTimer = 1;
	static private PlayerController player;

	private void Start() {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}

	public void Die()
	{
		if(player.invincibility == false)
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		else if(player.invincibilityCount != 0)
			player.invincibilityCount--;
	} 

	public void Invincibility()
	{
		player.invincibilityCount++;
	}

	public void TempInvincibility()
	{
		player.invincibilityTimer = InvincibilityTimer;
	}

	public void Dash(){
		player.dashTimer = dashTimer;
		player.invincibilityTimer = dashTimer;
	}

	public void Inverser() {
		player.reversed = !player.reversed;
	}

	public void gravityInverser() {
		player.reversedGravity = !player.reversedGravity;
		player.GetComponent<Rigidbody2D>().gravityScale = -player.GetComponent<Rigidbody2D>().gravityScale;
		player.transform.localScale = new Vector3(player.transform.localScale.x,-player.transform.localScale.y,0);
	}
}
