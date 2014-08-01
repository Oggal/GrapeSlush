using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour {
	Vector3 realPosition= Vector3.zero;
	Quaternion realRotaion = Quaternion.identity;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (photonView.isMine) {
			//do nothing
			} else {
			transform.position = Vector3.Lerp (transform.position,realPosition,0.1f);
			transform.rotation = Quaternion.Lerp (transform.rotation,realRotaion,0.1f);
			}
	}

	public void OnPhontonSerializeView(PhotonStream stream, PhotonMessageInfo info){

		if (stream.isWriting) {
			//Client's Player
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
		} else {
			//Other Player
			realPosition = (Vector3)stream.ReceiveNext();
			realRotaion = (Quaternion)stream.ReceiveNext();
		}

	}
	
}
