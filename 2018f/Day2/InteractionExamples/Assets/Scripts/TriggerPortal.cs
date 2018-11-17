using UnityEngine;
using System.Collections;

public class TriggerPortal : MonoBehaviour {

	public float delay = 2f;
	public TriggerZone triggerZone;

	private float markTriggerTime = 0f;
	private float markLookAtTime = 0f;
	private SceneLoader sceneLoader;
	private CardboardHead head;
	private Collider collider;
	//private CardboardInputController cardboardInputController;
	//public AudioSource audio;

	void Awake() {
		//audio = GetComponent<AudioSource>();
		collider = GetComponent<Collider>();
	}

	void Start() {
		head = Camera.main.GetComponent<StereoController>().Head;
		sceneLoader = GameObject.FindGameObjectWithTag("Loader").GetComponent<SceneLoader>();
		//screenFader = GameObject.FindGameObjectWithTag("Loader").GetComponent<ScreenFader>();
		//cardboardInputController = GameObject.FindGameObjectWithTag("Player").GetComponent<CardboardInputController>();
	}

	void Update() {
		RaycastHit hit;
		bool isLookedAt = collider.Raycast(head.Gaze, out hit, Mathf.Infinity);

		if (isLookedAt && markLookAtTime == 0f) {
			markLookAtTime = Time.realtimeSinceStartup;
		}

		if (triggerZone.trigger && markTriggerTime == 0f) { 
			markTriggerTime = Time.realtimeSinceStartup; 
		}

		//if (cardboardInputController.directionVector.z != 0 && isLookedAt && triggerZone.triggered && Time.realtimeSinceStartup > markTime + delay) {
		if (isLookedAt && triggerZone.trigger && Time.realtimeSinceStartup > markTriggerTime + delay && Time.realtimeSinceStartup > markLookAtTime + delay) {
			sceneLoader.sceneActivate();
			//screenFader.nextScene = true;
			//screenFader.fadeIn = false;
		}
	}

}
