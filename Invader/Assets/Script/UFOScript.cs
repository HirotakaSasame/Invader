using UnityEngine;
using System.Collections;

public class UFOScript : MonoBehaviour {

	private float speedX = 0.1f;
	
	public GameObject gameManagerPrefab;
	private GameManagerScript gms;
	public GameObject explotionPrefab;
	
	
	void Start () {
		gms = gameManagerPrefab.GetComponent< GameManagerScript >();
	}
	

	void Update () {
		
		// 移動.
		this.transform.Translate( -speedX, 0.0f, 0.0f );
		if ( this.transform.position.x < -11 ) {
			Destroy( this.gameObject );
		}
	}
	
	void OnCollisionEnter( Collision collision ) {
		GameObject obj = collision.gameObject;
		if ( obj.tag == "Beam" ) {
			Instantiate( explotionPrefab, this.transform.position, this.transform.rotation );
			Destroy( this.gameObject );
			gms.setFalse();
			gms.addUFOScore();
		}
	}
}
