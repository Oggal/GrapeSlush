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
		Vector3 vec;
		Transform hitTransform = FindClosestHitInfo (ray, out vec);
		if (hitTransform != null) {
			Debug.Log("HIT!");

			LivingStats h = hitTransform.GetComponent<LivingStats>();

			if(h==null){ 
			
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
}
