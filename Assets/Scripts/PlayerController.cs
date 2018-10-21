using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[Header("Player Attributes")]
	[Tooltip("Player input speed")]
	public float speed;
	[Tooltip("Jump force")]
	public float jumpForce;
	[Tooltip("Player's dashing speed")]
	public float dashSpeed;
	static public PlayerBuffScript playerBuff;
	static public TriggerEffectScript playerEffects;

	public Sprite skin1, skin2;

	public bool reversed { get {if(_reversed == -1) return true; else return false;} set {if(value == true) _reversed = -1; else _reversed = 1;} }
	public bool reversedGravity { get {if(_reversedGravity == -1) return true; else return false;} set {if(value == true) _reversedGravity = -1; else _reversed = 1;} }
	public bool invincibility { get {if(invincibilityCount > 0 || invincibilityTimer > 0) return true; else return false; } }

	[HideInInspector]
	public int invincibilityCount = 0;
	[HideInInspector]
	public float invincibilityTimer = 0, dashTimer = 0;

	private bool grounded;
	private Rigidbody2D rb;
	private int nbGrounded = 0, _reversed = 1, _reversedGravity = 1;
	private bool dash = false, tempInv = false;
	

	private void Start() {
		playerBuff = GameObject.FindGameObjectWithTag("PlayerBuff").GetComponent<PlayerBuffScript>();
		playerEffects = GameObject.FindGameObjectWithTag("PlayerEffects").GetComponent<TriggerEffectScript>();
		rb = GetComponent<Rigidbody2D>();
		dash = playerBuff.dash;
		tempInv = playerBuff.tempInv;

		if(playerBuff.skin == 1)
		{
			GetComponent<SpriteRenderer>().sprite = skin1;
		} else if (playerBuff.skin == 2)
		{
			GetComponent<SpriteRenderer>().sprite = skin2;
		}

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (dash && Input.GetAxisRaw("Fire1") == 1)
		{
			playerEffects.Dash();
			dash = false;
		}
		if (tempInv && Input.GetAxisRaw("Fire2") == 1)
		{
			playerEffects.TempInvincibility();
			tempInv = false;
		}
		Move();
		if(Input.GetAxisRaw("Vertical") > 0 && grounded)
			rb.velocity += Vector2.up *  jumpForce * _reversedGravity;
		if(invincibilityTimer > 0)
			invincibilityTimer -= Time.fixedDeltaTime;
		if(dashTimer > 0)
			dashTimer -= Time.deltaTime;
	}

	private void Move()
	{
		if(Input.GetAxisRaw("Horizontal") != 0 && dashTimer <= 0)
			transform.position += Vector3.right * speed * Time.fixedDeltaTime * Mathf.Sign(Input.GetAxisRaw("Horizontal")) * _reversed;
		else if (dashTimer > 0)
			transform.parent.position += Vector3.right * dashSpeed * Time.fixedDeltaTime;
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.CompareTag("ground"))
		{
			PlatformScript ptr = other.gameObject.GetComponent<PlatformScript>();
			if(ptr.reversed == reversedGravity)
			{
				grounded = true;
				nbGrounded++;
			}
		}
	}

	private void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.CompareTag("ground"))
			if(nbGrounded != 0)
				nbGrounded--;
			if(nbGrounded == 0)
				grounded = false; 
	}
}
