using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{


	}
	void OnMouseOver()
	{
		transform.localScale = new Vector2(0.5F,0.5F);
	}
	void OnMouseExit()
	{
		transform.localScale = new Vector2(0.4F,0.4F);
	}
}
