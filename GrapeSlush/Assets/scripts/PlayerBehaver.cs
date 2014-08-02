using UnityEngine;
using System.Collections;

public class PlayerBehaver : LivingStats {

	[RPC]
	public void TakeDamage(float f1){
		CurentHealth = CurentHealth-f1;
		if (CurentHealth <= 0) {
			Kill ();
		}
	}

	void Kill () {
		((ParticleSystem)gameObject.transform.FindChild ("Poof").gameObject.particleSystem).Emit (50);
	}
}
