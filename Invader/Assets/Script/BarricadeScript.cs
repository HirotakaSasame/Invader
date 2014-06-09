using UnityEngine;
using System.Collections;

public class BarricadeScript : MonoBehaviour {
	
	void OnCollisionEnter( Collision collision ) {
		GameObject obj = collision.gameObject;
		if ( obj.tag == "Beam" || obj.tag == "EnemyBeam" ) {
			Destroy( this.gameObject );
		}
	}
}
