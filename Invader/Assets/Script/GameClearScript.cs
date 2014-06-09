using UnityEngine;
using System.Collections;

public class GameClearScript : MonoBehaviour {

	public GameObject gameManagerPrefab;
	private GameManagerScript gms;
	public GUISkin skin1;

	void Start () {
		gms = gameManagerPrefab.GetComponent< GameManagerScript >();
	}
	
	void Update () {
	
	}
	
	void OnGUI() {
		GUI.skin = skin1;
		if ( GUI.Button( new Rect(Screen.width/2-(200/2),400,200,60), "NEXT" ) ) {
			gms.incLevel();
			Application.LoadLevel( "GameScene" );
		}
		if ( GUI.Button( new Rect(Screen.width/2-(200/2),500,200,60), "QUIT" ) ) {
			Application.Quit();
		}
	}
}
