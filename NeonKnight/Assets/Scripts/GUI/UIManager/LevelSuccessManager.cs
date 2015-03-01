using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class LevelSuccessManager : MonoBehaviour 
{
	public Canvas levelSuccessCanavs;

	public Text collectibleCount;
	public Image megaByteOne;
	public Image megaByteTwo;
	public Image megaByteThree;

	public void EnableOverlay(bool enabled)
	{
		levelSuccessCanavs.enabled = enabled;
		if(enabled)
		{
			DisplayBitByteScore();
			DisplayMegaByteScore();
		}
	}

	void DisplayBitByteScore()
	{
			collectibleCount.text = PersistantData.data.bits.ToString();
	}

	void DisplayMegaByteScore()
	{
		Color tempColor;
		if(PersistantData.data.megaBytesPerLevel[Application.loadedLevel][0])
		{
			tempColor = megaByteOne.color;
			tempColor.a = 255;
			megaByteOne.color = tempColor;
		}
		if(PersistantData.data.megaBytesPerLevel[Application.loadedLevel][1])
		{
			tempColor = megaByteTwo.color;
			tempColor.a = 255;
			megaByteTwo.color = tempColor;
		}
		if(PersistantData.data.megaBytesPerLevel[Application.loadedLevel][2])
		{
			tempColor = megaByteThree.color;
			tempColor.a = 255;
			megaByteThree.color = tempColor;
		}
	}

	public void ReturnToTitle()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}

