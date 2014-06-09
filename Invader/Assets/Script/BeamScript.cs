using UnityEngine;
using System.Collections;

public class BeamScript : MonoBehaviour {
	
	public GameObject gameManagerPrefab;
	private GameManagerScript gms;
	
	void Start() {
		gms = gameManagerPrefab.GetComponent< GameManagerScript >();
	}

	void Update () {
		this.transform.Translate( 0.0f, 0.2f, 0.0f );
	}
	
	void OnBecameInvisible() {
		Destroy( this.gameObject );
		gms.setFalse();
	}
	
	void OnCollisionEnter( Collision collision ) {
		GameObject obj = collision.gameObject;
		if ( obj.tag == "Invader" || obj.tag == "UFO" || obj.tag == "EnemyBeam" || obj.tag == "Barricade") {
			Destroy( this.gameObject );
			gms.setFalse();
		}
	}
}
