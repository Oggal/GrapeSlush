using UnityEngine;
using System.Collections;

public class SpellCast : MonoBehaviour {

	public float damage = 20;
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Fire();
		}
		if (Input.GetButtonDown ("Fire2")) {
			AltFire();
		}
	}

	void Fire(){
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		Vector3 hitpos;
		Transform hitTransform = FindClosestHitInfo (ray,out hitpos);
		if (hitTransform != null) {
			Debug.Log("HIT!");
			
			LivingStats h = hitTransform.GetComponent<LivingStats>();
			
			if(hitTransform!=null){ 
				GameObject orb = PhotonNetwork.Instantiate("Spell Orb",gameObject.transform.position,gameObject.transform.rotation,0);
				Debug.DrawLine(gameObject.transform.position,hitpos,Color.cyan,20.0f);
				orb.GetComponent<SpellProjecttile>().HitPos = hitpos;
			}
			
			if(h != null){
				Debug.Log("Yes???");
				//h.TakeDamage(2000);
				h.GetComponent<PhotonView>().RPC ("TakeDamage",PhotonTargets.All,damage);
			}
		}
	}

	void AltFire(){
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		Vector3 hitpos;
		Transform hitTransform = FindClosestHitInfo (ray,out hitpos);
		if (hitTransform != null) {
			Debug.Log("HIT!");
			
			LivingStats h = hitTransform.GetComponent<LivingStats>();
			
			if(hitTransform!=null){ 
				GameObject orb = PhotonNetwork.Instantiate("Spell Orb",gameObject.transform.position,gameObject.transform.rotation,0);
				Debug.DrawLine(gameObject.transform.position,hitpos,Color.cyan,20.0f);
				orb.GetComponent<SpellProjecttile>().HitPos = hitpos;
			}
			
			if(h != null){
				Debug.Log("Yes???");
				//h.TakeDamage(2000);
				h.GetComponent<PhotonView>().RPC ("TakeDamage",PhotonTargets.All,damage);
			}
		}
	}

	Transform FindClosestHitInfo(Ray ray,out Vector3 vec){
		RaycastHit[] hits = Physics.RaycastAll (ray);


		Transform closestHit = null;
		float dis = 0;
		vec = Vector3.zero;

		foreach (RaycastHit hit in hits) {

			if(hit.transform != this.transform &&( closestHit == null || hit.distance < dis)){
				closestHit =  hit.transform;
				dis = hit.distance;
				vec = hit.point;
			}
		}
		return  closestHit;
	}

	void OnGUI(){
		GUI.Label (new Rect (10,Screen.height-80,200,40), "Health: "+gameObject.GetComponent<LivingStats>().getHealth());
		GUI.Label (new Rect (10,40,100,20), GUI.tooltip);
		}
}
