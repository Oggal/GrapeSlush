using UnityEngine;
using System.Collections;

public class MineBehavior : LivingStats {

	public float Radius = 10f;
	public float Damage = 10f;

	[RPC]
	public void TakeDamage(float f1){
		CurentHealth = CurentHealth-f1;
		if (CurentHealth <= 0) {
			Kill ();
		}
	}
	
	void Kill(){
		//Get all of the GameObjects with a LivingStats
		object[] allObjects = FindObjectsOfTypeAll(typeof(GameObject)) ;
		 ArrayList Targets = new ArrayList();
		 foreach (object thisObject in allObjects) {
			if (((GameObject)thisObject).activeInHierarchy) {
				print (thisObject + " is an active object");
				if (((GameObject)thisObject).GetComponent<LivingStats> () != null) {
					Targets.Add((GameObject)thisObject);
				}
			}
		}
		//If it's in Radius, Deal Damage
		foreach (Object obj in Targets) {
			//Find distance, if it's > radius then return/brake/whateves
			//if(((GameObject)obj).transform.position.
		}

	}

}
