using UnityEngine;
using System.Collections;

public class BreakableProp : LivingStats {

	[RPC]
	public void TakeDamage(float f1){
		CurentHealth = CurentHealth-f1;
		if (CurentHealth <= 0) {
			Kill ();
		}
	}

	void Kill(){
	if(GetComponent<PhotonView>().instantiationId == 0){ 
		Destroy(gameObject); 
	}else{
		if(GetComponent<PhotonView>().isMine) 
			PhotonNetwork.Destroy(gameObject);
	}
}﻿
}
