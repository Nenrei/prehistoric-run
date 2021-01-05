using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunController : MonoBehaviour {

	public GameObject deathPoint;
	public Color stunColor;
	public Color stunSemiColor;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.name == "Roar") {
			SetStunned ();
			Invoke ("SetSemiStunned", 1f);
			Invoke ("SetNoStunned", 1.5f);
		}else if(coll.gameObject.name == "Player" && coll.gameObject.GetComponent<PlayerMovement> ().autoJump){
			coll.gameObject.GetComponent<PlayerMovement> ().Jump ();
		}
	}

	void SetStunned(){
		anim.SetBool ("stunned", true);
		GameData.usedRoars++;
		deathPoint.GetComponent<EdgeCollider2D> ().enabled = false;
		GetComponent<SpriteRenderer> ().color = stunColor;
	
	}

	void SetSemiStunned(){
		GetComponent<SpriteRenderer> ().color = stunSemiColor;
	}

	void SetNoStunned(){
		anim.SetBool ("stunned", false);
		deathPoint.GetComponent<EdgeCollider2D> ().enabled = true;
		GetComponent<SpriteRenderer> ().color = Color.white;
	}
}
