using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public GameObject pointer;
	public GameObject bulletObject;

	private Vector2 aim = new Vector2(0, 1);

	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;

		// Grab the input axes (WASD/arrow keys/left stick)
		float deltaX, deltaZ;
		deltaX = Input.GetAxis ("Horizontal");
		deltaZ = Input.GetAxis ("Vertical");
		
		pos += new Vector3 (deltaX, 0, deltaZ);
		transform.position = pos;

		// Grab mouse position
		float mouseX, mouseY;
		Vector3 mouse = Input.mousePosition;
		mouseX = mouse.x - Screen.width/2;
		mouseY = mouse.y - Screen.height/2;
		//Debug.Log ("Mouse " + mouseX.ToString () + ", " + mouseY.ToString ());

		// Move the pointer to match
		if (mouseX != 0 && mouseY != 0) {
			float angle = Mathf.Atan2 (mouseY, mouseX);
			Vector3 euler = pointer.transform.rotation.eulerAngles;
			euler.y = Mathf.Rad2Deg * (-angle) + 90;
			Quaternion newRot = Quaternion.Euler (euler);
			pointer.transform.rotation = newRot;

			// Update the aim vector
			aim.x = mouseX;
			aim.y = mouseY;
			aim.Normalize ();
		}

		GameObject newBullet = Instantiate (bulletObject);
		float bulletAngle = Mathf.Atan2 (aim.y, aim.x);
		Vector3 bulletEuler = newBullet.transform.rotation.eulerAngles;
		bulletEuler.y = Mathf.Rad2Deg * (-bulletAngle) + 90;
		Quaternion newBulletRot = Quaternion.Euler (bulletEuler);
		newBullet.transform.rotation = newBulletRot;
	}
}
