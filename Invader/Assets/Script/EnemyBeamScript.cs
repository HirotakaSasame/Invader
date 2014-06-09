using UnityEngine;
using System.Collections;

public class EnemyBeamScript : MonoBehaviour {

	
	void Start() {
	}

	void Update () {
		this.transform.Translate( 0.0f, -0.2f, 0.0f );
	}
	
	void OnCollisionEnter( Collision collision ) {
		GameObject obj = collision.gameObject;
		if ( obj.tag == "Line" || obj.tag == "Player" || obj.tag == "Beam" || obj.tag == "Barricade" ) {
			Destroy( this.gameObject );
		}
	}
}
