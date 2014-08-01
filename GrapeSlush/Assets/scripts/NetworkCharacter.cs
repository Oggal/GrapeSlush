using UnityEngine;
using System.Collections;

public class NetworkCharacter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnPhontonSerializeView(PhotonStream stream, PhotonMessageInfo info){

		if (stream.isWriting) {
			//Client's Player
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		} else {
			//Other Player
			transform.position = (Vector3)stream.ReceiveNext();
			transform.rotation = (Quaternion)stream.ReceiveNext();
		}

	}
}
