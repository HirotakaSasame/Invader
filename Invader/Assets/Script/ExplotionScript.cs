using UnityEngine;
using System.Collections;

public class ExplotionScript : MonoBehaviour {

	private float time;
	
	void Start () {
		time = 0.0f;
	}
	

	void Update () {
		time += Time.deltaTime;
		if ( time > 1.0f ) {
			Destroy( this.gameObject );
		}
	}
}
