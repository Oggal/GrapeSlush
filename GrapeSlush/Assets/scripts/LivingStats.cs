using UnityEngine;
using System.Collections;


public class LivingStats : MonoBehaviour {

	public float maxHealth = 100.0f;
	float CurentHealth;
	float lastdeath = 0;
	//public GameObject self;	//THIS MUST BE SET!!!
	// Use this for initialization
	void Start () {
		CurentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

	}

	//
	public void TakeDamage(float f1){
		CurentHealth = CurentHealth-f1;
		if (CurentHealth <= 0) {
			Kill ();
				}
	}

	void Kill(){
		((ParticleSystem)gameObject.transform.FindChild ("Poof").gameObject.particleSystem).Emit (50);

	}
}
