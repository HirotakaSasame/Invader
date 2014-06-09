using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	
	public GameObject gameManagerPrefab;
	private GameManagerScript gms;
	public GameObject explotionPrefab;
	
	private float acceletate = 0.05f;
	private float twinkleTime = 0;
	private float visibleTime = 0;
	private bool unrivaledFlag = true;
	private static int deadTimes = 0;

	void Start () {
		twinkleTime = 0;
		visibleTime = 0;
		unrivaledFlag = true;
		gms = gameManagerPrefab.GetComponent< GameManagerScript >();
	}
	

	void Update () {
		if ( deadTimes % 3 != 0 ) {
			if ( twinkleTime < 3.0f ) {
				if ( visibleTime > 0.1f ) {
					this.renderer.enabled = !(this.renderer.enabled);
					this.gameObject.transform.FindChild("cannon").renderer.enabled = !(this.gameObject.transform.FindChild("cannon").renderer.enabled);
					visibleTime = 0;
				}
				visibleTime += Time.deltaTime;
				twinkleTime += Time.deltaTime;
			}else{
				unrivaledFlag = false;
				this.renderer.enabled = true;
				this.gameObject.transform.FindChild("cannon").renderer.enabled = true;
			}
		}else{
			unrivaledFlag = false;
			twinkleTime = 5.0f;
		}
		
		Vector3 v = this.transform.position;
		v.x += Input.GetAxis("Horizontal") * acceletate;
		if ( v.x >= 6 ) {
			v.x = 6;
		}
		else if ( v.x <= -6 ) {
			v.x = -6;
		}
		this.transform.position = v;
	}
	
	void OnCollisionEnter( Collision collision ) {
		if ( collision.gameObject.tag == "EnemyBeam" && !unrivaledFlag ) {
			++deadTimes;
			Instantiate( explotionPrefab, this.transform.position, this.transform.rotation );
			Destroy( this.gameObject );
			gms.damagePlayer();
		}
	}
}
