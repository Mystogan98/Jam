using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEffectScript : MonoBehaviour {

	public float InvincibilityTimer = 3, dashTimer = 1;
	static private PlayerController player;
	static public PlayerBuffScript playerBuff;

	private void Start() {
		// if(Shop == null)
		// 	Shop = SceneManager.GetSceneByName("Shop");
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		playerBuff = GameObject.FindGameObjectWithTag("PlayerBuff").GetComponent<PlayerBuffScript>();
		InvincibilityTimer += 0.5f * playerBuff.dureeInv;
		dashTimer += 0.25f * playerBuff.dashDuration;
		player.dashSpeed += 2.5f * playerBuff.dashVitesse;
		player.invincibilityCount += (playerBuff.inv)?1:0;
	}

	public void Die()
	{
		if(player.invincibility == false)
		{
			if(player.transform.position.x > playerBuff.scoreMax)
				playerBuff.scoreMax = player.transform.position.x;
			playerBuff.morts++;
			SceneManager.LoadScene(1,LoadSceneMode.Single);
		}
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
