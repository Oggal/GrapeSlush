using UnityEngine;
using System.Collections;



public class FPS_Ctrl : MonoBehaviour {

	public float movementMod = 5.0f;
	public float rotationMod = 2.0f;
	public float pitchmax = 60.0f;
	public float jumpPower = 10.0f;

	float vertVeloc = 0.0f;

	float vertRot = 0.0f;
	// Use this for initialization
	void Start () {
		Screen.lockCursor= true;
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController cc = GetComponent<CharacterController> ();

		float LR_Rot = Input.GetAxis ("Mouse X") * rotationMod;
		
		transform.Rotate (0, LR_Rot, 0);

		vertRot -= Input.GetAxis ("Mouse Y") * rotationMod;
		vertRot = Mathf.Clamp (vertRot, -pitchmax, pitchmax);
		Camera.main.transform.localRotation = Quaternion.Euler (vertRot, 0, 0);

		float vertSpeed = Input.GetAxis ("Vertical") * movementMod;
		float LRSpeed = Input.GetAxis ("Horizontal") * movementMod;
		if (!cc.isGrounded) {
			vertVeloc += Physics.gravity.y * Time.deltaTime;
		}
		if(Input.GetButtonDown("Jump")&& cc.isGrounded){
			vertVeloc = jumpPower;
		}

		Vector3 speed = new Vector3 (LRSpeed, vertVeloc, vertSpeed);

		Vector3 newspeed = transform.rotation * speed;



		cc.Move (newspeed*Time.deltaTime);

	}
}
