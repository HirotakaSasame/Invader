using UnityEngine;
using System.Collections;

public class EmitterScript : MonoBehaviour {
	
	public GameObject beamPrefab;
	public GameObject gameManagerPrefab;
	private GameManagerScript gms;
	
	void Start() {
		gms = gameManagerPrefab.GetComponent< GameManagerScript >();
	}
	
	void Update () {
		bool flag = gms.getShotFlag();
		if ( Input.GetKeyDown(KeyCode.Space) && (flag == false) ) {
			Instantiate( this.beamPrefab, this.transform.position, this.transform.rotation );
			gms.setTrue();
		}
	}
}
