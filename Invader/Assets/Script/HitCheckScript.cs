using UnityEngine;
using System.Collections;

public class HitCheckScript : MonoBehaviour {

	public bool hitFlag = false;
		
	void Start() {
		hitFlag = false;
	}
	
	void Update() {
		hitFlag = false;
	}
	
	void OnTriggerStay( Collider collision ) {
		if ( collision.gameObject.tag == "Invader" ) {
			hitFlag = true;
		}
	}
	
	public bool getHitFlag() {
		return hitFlag;
	}
}
