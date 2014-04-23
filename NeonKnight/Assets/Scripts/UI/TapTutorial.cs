using UnityEngine;
using System.Collections;

public class TapTutorial : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTap(TapGesture gesture)
	{
		//Debug.Log (gesture.Selection.name);
	}
//	void OnDrag( DragGesture gesture ) 
//	{
//		if( gesture.Selection )
//			Debug.Log( "Dragged object: " + gesture.Selection.name );
//		else
//			Debug.Log( "No object was dragged at " + gesture.Position );
//	}
}
