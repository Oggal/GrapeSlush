using UnityEngine;
using System.Collections;

public class Oggal_was_Bored : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("Oggal was Bored is still in the game!!");
	}
	
	// Update is called once per frame
	void Update () {
		//lets see what we can do here...
		if (PhotonNetwork.inRoom && PhotonNetwork.countOfPlayers >= 2) {
			Debug.Log("You are in room " + PhotonNetwork.room.ToString() + "!");		
		}
	}
}
