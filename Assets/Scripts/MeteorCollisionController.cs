using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCollisionController : MonoBehaviour {

	public Transform despPoint;
	float vel = 0.25f;

	void Update(){
		if (despPoint != null) {
			if (gameObject.activeInHierarchy) {
				if (transform.localScale.x < 0.5f) {
					vel = 0.15f;
				} else {
					vel = 0.25f;
				}
				transform.localPosition = Vector3.MoveTowards (transform.localPosition, new Vector3 (despPoint.localPosition.x, despPoint.localPosition.y, 1f), vel);
			}

			if (transform.localPosition.y == despPoint.localPosition.y) {
				gameObject.SetActive (false);
				transform.localPosition = new Vector3 (0f, 0f, 0f);
			}
		}

	}

}
