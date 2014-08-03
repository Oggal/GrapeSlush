using UnityEngine;
using System.Collections;

public class PlayerBehaver : LivingStats {

	[RPC]
	override public void TakeDamage(float f1){
		CurentHealth = CurentHealth-f1;
		if (CurentHealth <= 0) {
			Kill ();
			((ParticleSystem)gameObject.transform.FindChild ("Poof").gameObject.particleSystem).Emit (Mathf.FloorToInt(50));
		}
	}

	override protected void Kill () {
		if (GetComponent<PhotonView> ().isMine) {
			NetworkManager nm = GameObject.FindObjectOfType <NetworkManager>();
			nm.respawnTime = 2.0f;
			PhotonNetwork.Destroy(gameObject);
		}

	}
}
