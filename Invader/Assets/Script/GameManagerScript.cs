using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	
	private const int ENEMY_MAX = 55;
	
	private GUISkin skin;
	public static int score = 0;
	private static int hiScore = 0;
	private static int level = 0;
	private static bool playerFlag;
	private static int life;
	private static int enemyNum;
	private static float enemyLowestY;
	private static bool[] invaders = new bool[ENEMY_MAX];
	private static int sequenceFlag;
	private bool shotFlag;
	private bool ufoFlag;
	private int  ufoTimeIndex;
	private float[] ufoTimeTable = new float[]{ 30.0f, 40.0f, 50.0f, 60.0f };
	private float time;
	private float restartTime;
	private float sequenceTime;
	
	public GameObject playerPrefab;
	public GameObject UFOPrefab;

	void Start () {
		ufoTimeIndex = Random.Range( 0, 3 );
		time = 0;
		restartTime = 0;
		sequenceTime = 0;
		life = 3;
		enemyNum = ENEMY_MAX;
		enemyLowestY = 3.0f;
		sequenceFlag = 0;
		shotFlag = false;
		ufoFlag = false;
		for ( int i = 0; i < ENEMY_MAX; ++i ) {
			invaders[i] = true;
		}
		
		skin = new GUISkin();
		skin.label.alignment = TextAnchor.LowerRight;
		skin.label.fontSize = 20;
		skin.label.normal.textColor = Color.white;
		
		Instantiate( playerPrefab, new Vector3(0.0f, -3.5f, 0.0f), Quaternion.identity );
		playerFlag = true;
	}
	

	void Update () {
		if ( sequenceFlag != 0 ) {
			sequenceTime += Time.deltaTime;
			if ( sequenceTime > 1.5f ) {
				scoreUpdate();
				switch( sequenceFlag ) {
					case 1: Application.LoadLevel( "GameOverScene"  ); break;
					case 2: Application.LoadLevel( "GameClearScene" ); break;
				}
			}
		}
		time += Time.deltaTime;
		if ( time > ufoTimeTable[ufoTimeIndex] && !ufoFlag) {
			Instantiate( UFOPrefab, new Vector3( 11.0f, 8.5f, 0.0f ), Quaternion.identity );
			ufoFlag = true;
		}
		
		if ( life > 0 && !playerFlag ) {
			if ( restartTime > 1.0f ) {
				Instantiate( playerPrefab, new Vector3(0.0f, -3.5f, 0.0f), Quaternion.identity );
				playerFlag = true;
				switch( life ) {
					case 2: Destroy( GameObject.Find("PlayerLife2") ); break;
					case 1: Destroy( GameObject.Find("PlayerLife1") ); break;
				}
				restartTime = 0.0f;
			} else {
				restartTime += Time.deltaTime;
			}
		}
	}
	
	void OnGUI() {
		GUI.skin = skin;
		GUI.Label( new Rect(0,0,Screen.width,30), "LEVEL:"+(level+1));
		skin.label.alignment = TextAnchor.LowerRight;
		GUI.Label( new Rect(0,0,Screen.width,30), "SCORE:"+score);
		skin.label.alignment = TextAnchor.LowerCenter;
		GUI.Label( new Rect(0,Screen.height-40,Screen.width,30), "Move: [left or right]     Shoot: [space]" );
		skin.label.alignment = TextAnchor.LowerLeft;
	}
	
	public int getLevel()				{ return level;	}
	public void incLevel()				{ level++;	 	}
	
	public int getHiScore()				{ return hiScore;	}
	public int getScore()				{ return score; 	}
	public void resetHiScore()			{ hiScore = 0;		}
	public void resetScore()			{ score = 0; 		}
	public void addScore( int amount )	{ score += amount;  }
	public void addUFOScore()			{ score += 300; 	}
	public void scoreUpdate() {
		if ( hiScore < score )	{ hiScore = score; }
	}
	
	public bool getShotFlag()	{ return shotFlag;	}
	public void setTrue() 		{ shotFlag = true;  }
	public void setFalse() 		{ shotFlag = false; }
	
	public float getEnemyLowestY()	{ return enemyLowestY; }
	public void setEnemyLowestY( float y )
	{
		enemyLowestY = Mathf.Min( enemyLowestY, y );
	}
	
	public void killEnemy( int id )
	{
		--enemyNum;
		if ( enemyNum <= 0 ) {
			sequenceFlag = 2;
		}
		invaders[ id ] = false;
	}

	
	public void damagePlayer()
	{
		--life;
		playerFlag = false;
		if ( life <= 0 ) {
			sequenceFlag = 1;
		}
	}
	
	public bool canShoot( int id )
	{
		if ( id < 44 ) {
			return !( invaders[ id + 11 ] );
		} else {
			return true;
		}
	}
	
}
