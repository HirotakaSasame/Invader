using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {

	public GUISkin skin;

	void Start () {

	}
	
	void Update () {
	
	}
	
	void OnGUI() {
		GUI.skin = skin;
		if ( GUI.Button( new Rect(Screen.width/2-(200/2),400,200,60), "START" ) ) {
			Application.LoadLevel( "GameScene" );
		}
	}
}
