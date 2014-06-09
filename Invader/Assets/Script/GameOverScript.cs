using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
	
	public GameObject gameManagerPrefab;
	private GameManagerScript gms;
	private GUISkin skin1;
	public GUISkin skin2;

	void Start () {
		gms = gameManagerPrefab.GetComponent< GameManagerScript >();

		skin1 = new GUISkin();
		skin1.label.alignment = TextAnchor.UpperCenter;
		skin1.label.fontSize = 45;
		skin1.label.normal.textColor = Color.gray;		
	}
	
	void OnGUI() {
		GUI.skin = skin1;
		GUI.Label( new Rect(0, 300, Screen.width, 45), "HISCORE : "+gms.getHiScore() );
		GUI.Label( new Rect(0, 345, Screen.width, 45), "  SCORE : "+gms.getScore() );
		GUI.skin = skin2;
		if ( GUI.Button( new Rect(Screen.width/2-(200/2),410,200,60), "RETRY" ) ) {
			gms.resetScore();
			Application.LoadLevel( "GameScene" );
		}
		if ( GUI.Button( new Rect(Screen.width/2-(200/2),480,200,60), "QUIT" ) ) {
			Application.Quit();
		}
		if ( GUI.Button( new Rect(Screen.width/2-(200/2),560,200,25), "RESET HISCORE" ) ) {
			gms.resetHiScore();
		}
	}
}
