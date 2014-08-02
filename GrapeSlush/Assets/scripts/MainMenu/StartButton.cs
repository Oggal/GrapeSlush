using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	float deltaRot = 0;
	bool mouseIsInsideMe = false;
	public float speed = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//transform.Rotate (Vector3.up, 100f * Time.deltaTime);		120,20,120
		float rot = speed * Time.deltaTime;
		transform.Rotate(0,rot,0);
		deltaRot = deltaRot + rot;
		if (deltaRot >= 89f) {
			deltaRot = -89f;
			transform.rotation = Quaternion.Euler(0,-89,0);
		}
		if (Input.GetKey (KeyCode.Mouse0)) {
			OnClicked();
				}
	}

	void OnMouseEnter(){
		mouseIsInsideMe = true;
		Debug.Log (Application.loadedLevel);
	}
	void OnMouseExit(){
		mouseIsInsideMe = false;
	}
	void OnClicked(){
		if (mouseIsInsideMe) {
			Application.LoadLevel(1);
		}
	}

}
