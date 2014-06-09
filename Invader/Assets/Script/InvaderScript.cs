using UnityEngine;
using System.Collections;

public class InvaderScript : MonoBehaviour {
	
	public  int score;
	private float time = 0;
	private float cycle = 1.0f;
	private float speedX = 0.25f;
	private int moved = 0;
	private int totalMoved = 0;
	private int id = 0;
	private int rndRange = 0;
	
	public GameObject gameManagerPrefab;
	private GameManagerScript gms;
	public GameObject enemyBeamPrefab;
	public GameObject explotionPrefab;
	
	
	void Start () {
		gms = gameManagerPrefab.GetComponent< GameManagerScript >();
		int col = (int)Mathf.Abs( -7.0f - this.transform.position.x );
		int row = (int)Mathf.Abs(  7.0f - this.transform.position.y );
		id = row*11 + col;
		rndRange = 900 - gms.getLevel() * 20;
		if ( rndRange <= 50 ) { rndRange = 50; }
	}
	

	void Update () {
		
		// 移動.
		time += Time.deltaTime;
		if ( time >= cycle ) {
			this.transform.Translate( speedX, 0.0f, 0.0f );
			gms.setEnemyLowestY( this.transform.position.y );
			++moved;
			++totalMoved;

			if ( moved >= 16 ) {
				speedX *= -1.0f;
				cycle -= 0.2f;
				if ( cycle < 0.1f ) {
					cycle = 0.1f;
				}
				moved = 0;
			}
			
			float lowestY = gms.getEnemyLowestY();
			if ( totalMoved >= 32 && lowestY >= 0 ) {
				this.transform.Translate( 0.0f, -1.0f, 0.0f );
				totalMoved = 0;
			}
			time = 0;
		}
		
		// 弾発射.
		//if ( this.transform.position.y <= 3 ) {
		//if ( this.transform.FindChild("HitCheck").GetComponent<HitCheckScript>().getHitFlag()){
		if ( gms.canShoot( id ) ){
			int rnd = (int)Random.Range(0, rndRange);
			if ( rnd == 1 ) {
				Vector3 position = this.transform.position;
				position.y -= 1.0f;
				Instantiate( enemyBeamPrefab, position, Quaternion.identity );
			}
		}
		
	}
	
	void OnCollisionEnter( Collision collision ) {
		GameObject obj = collision.gameObject;
		if ( obj.tag == "Beam" ) {
			Instantiate( explotionPrefab, this.transform.position, this.transform.rotation );
			Destroy( this.gameObject );
			gms.killEnemy( id );
			gms.setFalse();
			gms.addScore( score );
		}
	}

}
