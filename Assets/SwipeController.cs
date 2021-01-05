using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour {
	
	Vector2 firstPressPos;
	Vector2 secondPressPos;
	Vector2 currentSwipe;

	PowersController powers;
	PlayerMovement movement;
	ExtintionController extintion;

	float minX;

	// Use this for initialization
	void Awake () {
		powers = GameObject.Find("Player").GetComponent<PowersController> ();
		movement = GameObject.Find("Player").GetComponent<PlayerMovement> ();
		extintion = GameObject.Find ("MeteorPooler").GetComponent<ExtintionController> ();
		minX = transform.position.x - ((RectTransform)gameObject.transform).rect.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.touches.Length > 0)
		{
			Touch t = Input.GetTouch(0);
			if(t.phase == TouchPhase.Began)
			{
				//save began touch 2d point
				firstPressPos = new Vector2(t.position.x,t.position.y);
			}
			if(t.phase == TouchPhase.Ended)
			{
				//save ended touch 2d point
				secondPressPos = new Vector2(t.position.x,t.position.y);

				//create vector from the two points
				currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y, 0f);

				//normalize the 2d vector
				currentSwipe.Normalize();

				Swipe ();
			}
		}

		if(Input.GetMouseButtonDown(0))
		{
			//save began touch 2d point
			firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
		}
		if(Input.GetMouseButtonUp(0))
		{
			//save ended touch 2d point
			secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);

			//create vector from the two points
			currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

			//normalize the 2d vector
			currentSwipe.Normalize();

			Swipe ();
		}


	}

	private void Swipe(){
		//swipe upwards
		if (minX < currentSwipe.x) {
			if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
				UpSwipe ();
			}
			//swipe down
			else if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f) {
				DownSwipe ();
			}
			//swipe left
			else if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
				LeftSwipe ();
			}
			//swipe right
			else if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f) {
				RightSwipe ();
			}
		}
	}


	private void RightSwipe(){
		powers.UseRoar ();
	}

	private void LeftSwipe(){
		
	}

	private void UpSwipe(){
		
	}

	private void DownSwipe(){
		extintion.StartExtintion ();
	}
}
