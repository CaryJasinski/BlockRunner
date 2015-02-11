using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class StartMenuManager : MonoBehaviour 
{
	public Canvas startMenuCanvas;
	
	public void EnableOverlay(bool enabled)
	{
		startMenuCanvas.enabled = enabled;
	}
}
