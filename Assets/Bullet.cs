using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed;
	public float damage;
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos += transform.forward * speed;
		transform.position = pos;
	}
}
