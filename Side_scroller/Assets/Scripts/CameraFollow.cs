using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {


	public Transform target;
	public float smoothing = 100f;

	Vector3 offset;

	// Use this for initialization
	void Start () {

		offset = transform.position - target.position;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (target != null) {
			Vector3 targetCameraPosition = target.position + offset;

			transform.position = Vector3.Lerp (transform.position, targetCameraPosition, smoothing * Time.deltaTime);

			transform.position = new Vector3 (transform.position.x, Mathf.Clamp (transform.position.y, 2.25f, 2.25f), transform.position.z);
	
		}
	}
}
