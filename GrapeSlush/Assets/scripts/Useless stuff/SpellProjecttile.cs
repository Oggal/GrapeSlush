using UnityEngine;
using System.Collections;

public class SpellProjecttile : MonoBehaviour {
	public Vector3 HitPos;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position,HitPos,0.1f);
		if(transform.position.Equals(HitPos)){
			Destroy(gameObject);
		}
	}
}
