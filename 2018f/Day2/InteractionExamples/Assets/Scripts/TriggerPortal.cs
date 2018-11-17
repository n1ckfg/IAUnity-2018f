using UnityEngine;
using System.Collections;

public class TriggerPortal : MonoBehaviour {

	public float delay = 2f;
	public TriggerZone triggerZone;

	private float markTriggerTime = 0f;
	private float markLookAtTime = 0f;
	private SceneLoader sceneLoader;
	//private CardboardHead head;
	private Collider collider;

	void Awake() {
		collider = GetComponent<Collider>();
	}

	void Start() {
		//head = Camera.main.GetComponent<StereoController>().Head;
		sceneLoader = GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneLoader>();
	}

	void Update() {
		/*
		 RaycastHit hit;
		bool isLookedAt = collider.Raycast(head.Gaze, out hit, Mathf.Infinity);

		if (isLookedAt && markLookAtTime == 0f) {
			markLookAtTime = Time.realtimeSinceStartup;
		}

		if (triggerZone.trigger && markTriggerTime == 0f) { 
			markTriggerTime = Time.realtimeSinceStartup; 
		}

		if (isLookedAt && triggerZone.trigger && Time.realtimeSinceStartup > markTriggerTime + delay && Time.realtimeSinceStartup > markLookAtTime + delay) {
			sceneLoader.sceneActivate();
		}
		*/
	}

}
