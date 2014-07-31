using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	SpawnSpot[] Spawns;
	public Camera StandbyCamera;
	public string Version = "07312014-02.10_dev";
	// Use this for initialization
	void Start () {
		Spawns = GameObject.FindObjectsOfType<SpawnSpot>();
		Connect ();

	}

	void Connect () {
		PhotonNetwork.ConnectUsingSettings("GrapeSlush"+Version);
	}

	void OnGUI(){
		GUILayout.Label ( PhotonNetwork.connectionStateDetailed.ToString ());
	}

	void OnJoinedLobby(){
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed(){
		Debug.Log ("Join Random Room Failed!");
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom(){
		Debug.Log ("Joined Room");
		SpawnClientPlayer ();
	}

	void SpawnClientPlayer(){
		Debug.Log ("Player Spawned");

		SpawnSpot SpawnPoint = Spawns [Random.Range (0, Spawns.Length)];
		PhotonNetwork.Instantiate ("Player",SpawnPoint.transform.position, SpawnPoint.transform.rotation, 0);
		StandbyCamera.enabled = false;
	}
}