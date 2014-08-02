using UnityEngine;
using System.Collections;

public class SpellCast : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Fire();
		}
	}

	void Fire(){
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);

		Transform hitTransform = FindClosestHitInfo (ray);
		if (hitTransform != null) {
			Debug.Log("HIT!");

			LivingStats h = hitTransform.GetComponent<LivingStats>();

			if(h==null){ Debug.Log("Nope...");}

			if(h != null){
				Debug.Log("Yes???");
				h.TakeDamage(2000);
			}
		}
	}

	Transform FindClosestHitInfo(Ray ray){
		RaycastHit[] hits = Physics.RaycastAll (ray);

		bool hasHit = false;
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
