using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLocation2 : MonoBehaviour {

	public BasicController ctl;
	public float speed = 0f;
	public Vector3 offset = new Vector3(0f, 0.5f, 0f);

	[HideInInspector] public Vector3 target;

	private float delta = 0.0001f;
	private Vector3 origLoc;
	private bool isMoving = false;

	void Start() {
		origLoc = transform.position;
	}

	void Update()
	{
		if (ctl.isDrawing) {
			target = ctl.lastHitPos;
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

		transform.position = Vector3.Lerp(transform.position, target + offset, speed);
	}



}
