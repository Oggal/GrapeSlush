using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	public bool offlineMode = false;
	SpawnSpot[] Spawns;
	public GameObject StandbyCamera;
	public string Version = "07312014-02.10_dev";
	// Use this for initialization
	void Start () {
		Spawns = GameObject.FindObjectsOfType<SpawnSpot>();
		Connect ();

	}

	void Connect () {
		if(offlineMode){
			PhotonNetwork.offlineMode =true;
			OnJoinedLobby();
		}else{
		PhotonNetwork.ConnectUsingSettings("GrapeSlush"+Version);
		}
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
		GameObject MyPly =PhotonNetwork.Instantiate ("Player",SpawnPoint.transform.position, SpawnPoint.transform.rotation, 0);
		StandbyCamera.SetActive ( false);

		//((MonoBehaviour)MyPly.GetComponent("FPS_Ctrl")).enabled = true;
		((MonoBehaviour)MyPly.GetComponent("FPSInputController")).enabled = true;
		((MonoBehaviour)MyPly.GetComponent("MouseLook")).enabled = true;
		((MonoBehaviour)MyPly.GetComponent("CharacterMotor")).enabled = true;
		MyPly.transform.FindChild ("Main Camera").gameObject.SetActive( true);
	}
}