using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLocation1 : MonoBehaviour {

	public BasicController ctl;
	public Transform target;
	public float speed = 0f;

	private float delta = 0.0001f;
	private Vector3 origLoc;
	private bool isMoving = false;

	void Start() {
		origLoc = transform.position;
	}

	void Update() {
		if (ctl.clicked && ctl.isLookingAt == gameObject.name) {
			isMoving = true;
		} else if (!ctl.isDrawing) {
			isMoving = false;
		}

		if (isMoving) {
			speed += delta;
		} else {
			if (speed > 0f) {
				speed -= delta;
			} else if (speed < 0f) {
				speed = 0f;
			}
		}

		if (Input.GetKeyDown(KeyCode.R)) { // reset
			transform.position = origLoc;
			speed = 0f;
		}

		transform.position = Vector3.Lerp(transform.position, target.position, speed);
	}



}
