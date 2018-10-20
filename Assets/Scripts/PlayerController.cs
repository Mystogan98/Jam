﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[Header("Player Attributes")]
	[Tooltip("Player input speed")]
	public float speed;
	[Tooltip("Jump force")]
	public float jumpForce;

	private bool grounded;
	private Rigidbody2D rb;
	private int nbGrounded;

	private void Start() {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Move();
		if(Input.GetAxisRaw("Vertical") > 0 && grounded)
		{
			rb.velocity += Vector2.up *  jumpForce;
			//grounded = false;
		}
	}

	private void Move()
	{
		if(Input.GetAxisRaw("Horizontal") != 0)
			transform.position += Vector3.right * speed * Time.fixedDeltaTime * Mathf.Sign(Input.GetAxisRaw("Horizontal"));
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.CompareTag("ground"))
		{
			grounded = true;
			nbGrounded++;
		}
	}

	private void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.CompareTag("ground"))
			nbGrounded--;
			if(nbGrounded == 0)
				grounded = false;
	}
}
