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

		Transform hitTransform = FindClosestHitInfo (ray);
		if (hitTransform != null) {
			Debug.Log("HIT!");

			LivingStats h = hitTransform.GetComponent<LivingStats>();

			if(h==null){ 
			//TODO: shoot effects for other non-damage
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
		
		Transform hitTransform = FindClosestHitInfo (ray);
		if (hitTransform != null) {
			Debug.Log("HIT!");
			
			LivingStats h = hitTransform.GetComponent<LivingStats>();
			
			if(h==null){ 
				//TODO: shoot effects for other non-damage
			}
			
			if(h != null){
				Debug.Log("Yes???");
				//h.TakeDamage(2000);
				h.GetComponent<PhotonView>().RPC ("TakeDamage",PhotonTargets.All,damage);
			}
		}
	}

	Transform FindClosestHitInfo(Ray ray){
		RaycastHit[] hits = Physics.RaycastAll (ray);


		Transform closestHit = null;
		float dis = 0;


		foreach (RaycastHit hit in hits) {

			if(hit.transform != this.transform &&( closestHit == null || hit.distance < dis)){
				closestHit =  hit.transform;
				dis = hit.distance;

			}
		}
		return  closestHit;
	}
}
