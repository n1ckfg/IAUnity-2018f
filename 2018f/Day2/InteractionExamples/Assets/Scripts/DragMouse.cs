using System;
using System.Collections;
using UnityEngine;

public class DragMouse : MonoBehaviour {

    public bool clicked = false;
    public bool hitSuccess = false;
    public float dragDistance = 0f;

    void Update() {
        if (!Input.GetMouseButtonDown(0)) {
            clicked = false;
            return;
        } else {
            clicked = true;
        }

        Camera mainCamera = FindCamera();

        // We need to actually hit an object
        RaycastHit hit = new RaycastHit();
        if (!Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition).origin,
                             mainCamera.ScreenPointToRay(Input.mousePosition).direction, out hit, 100,
                             Physics.DefaultRaycastLayers)) {
            hitSuccess = false;
            return;
        }
        
        // We need to hit a rigidbody that is not kinematic
        if (!hit.rigidbody || hit.rigidbody.isKinematic) {
            hitSuccess = false;
            return;
        } else {
            hitSuccess = true;
        }

        StartCoroutine("DragObject", hit.distance);
    }

    private IEnumerator DragObject(float distance) {
        Camera mainCamera = FindCamera();
        while (Input.GetMouseButton(0)) {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            dragDistance = ray.GetPoint(distance);
            yield return null;
        }
    }

    private Camera FindCamera() {
        if (GetComponent<Camera>()) {
            return GetComponent<Camera>();
        }
        return Camera.main;
    }

}

