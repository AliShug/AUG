using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public Transform target;
	public float followSpeed = 0.2f;
	
	// Update is called once per frame
	void Update () {
		// Linear interpolation between current position and target's position
		Vector3 pos = transform.position;
		Vector3 targPos = target.position;

		transform.position = Vector3.Lerp (pos, targPos, followSpeed);
	}
}
