using UnityEngine;
using System.Collections;


public abstract class LivingStats : MonoBehaviour {

	public float maxHealth = 100.0f;
	protected float CurentHealth;
	protected float lastdeath = 0;
	//public GameObject self;	//THIS MUST BE SET!!!
	// Use this for initialization
	protected void Start () {
		CurentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

	}

	//
	[RPC]
	abstract public void TakeDamage(float f1);

	abstract protected void Kill();
}
