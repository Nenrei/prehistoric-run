using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour {
	public bool autoJump;

	public bool runEnabled;
	public bool grounded;
	public LayerMask whatIsGround;
	public float speed = 10;
	public float jumpForce = 5;
	public bool jumping;

	public bool dead;

	private Rigidbody2D body;
	private Collider2D collider;
	private Animator animator;

	AudioController audio;

	public bool hitGround;

	void Awake(){
		audio = GameObject.Find ("Audio").GetComponent<AudioController> ();
		body = GetComponent<Rigidbody2D> ();
		collider = GetComponent<Collider2D> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!dead) {
			animator.SetBool ("run", runEnabled);
			grounded = Physics2D.IsTouchingLayers (collider, whatIsGround);
			animator.SetBool ("grounded", grounded);

			jumping = !grounded;

			/*if (Input.GetKeyDown (KeyCode.R)) {
				runEnabled = !runEnabled;
				body.rotation = 0;
				GameObject.Find ("TimeCounter").GetComponent<TimeController> ().run = runEnabled;
			}*/

			if (runEnabled) {
				body.velocity = new Vector2 (speed, body.velocity.y);

				/*if (Input.GetKeyDown (KeyCode.J)) {
					Jump ();
				}*/

			} else {
				body.velocity = new Vector2 (0f, body.velocity.y);
			}

		} else {
			runEnabled = false;
			body.velocity = Vector2.zero;
			animator.SetBool ("run", runEnabled);
			GameObject.Find ("TimeCounter").GetComponent<TimeController> ().run = runEnabled;
		}

			
	}

	public void Jump(){
		if (grounded && runEnabled) {
			audio.PlayJump ();
			body.velocity = new Vector2 (body.velocity.x, jumpForce);
			hitGround = true;
		} else {
			gameObject.GetComponent<PowersController> ().UseFart ();
		}

	}

	void OnCollisionEnter2D(Collision2D col){
		
		if (col.gameObject.layer == 8 && hitGround) {
			hitGround = false;
			GameObject.Find ("CameraShake").GetComponent<CameraShake> ().Shake (0.1f, 0.05f);
		}


	}

	void OnTriggerEnter2D(Collider2D col){
		if (tag == "Triceratops" || tag == "Stegosaurio" || tag == "Spinosaurus") {
			Jump ();
		}
	}


	
}
