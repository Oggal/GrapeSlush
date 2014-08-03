using UnityEngine;
using System.Collections;

public class SpellProjecttile : MonoBehaviour {
	public Vector3 HitPos;
	float spawn;
	// Use this for initialization
	void Start () {
		spawn = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position,HitPos,0.5f);

		if (spawn +5  < Time.time) {
			PhotonNetwork.Destroy(gameObject);
				}
	}

}
