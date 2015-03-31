using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextLevelDisable : MonoBehaviour {

	public Button nextLevelButton;

	void Update()
	{
		if(Application.loadedLevelName == "LevelPrototype" && nextLevelButton.IsInteractable())
		{
			nextLevelButton.interactable = false;
		}
	}
}
