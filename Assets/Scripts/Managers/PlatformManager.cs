using UnityEngine;
using System.Collections;

public class PlatformManager : MonoBehaviour {

	private GameObject[] m_moveablePlatforms;

	public void InitializePlatorms()
	{
		m_moveablePlatforms = GameObject.FindGameObjectsWithTag ("MasterPlatform");
	}

	public void ResetPlatformPositions()
	{
		foreach(GameObject platform in m_moveablePlatforms)
		{
			if(platform.GetComponent<GodPlatform>() != null)
			{
				if(platform.GetComponent<GodPlatform>().platformType != GodPlatform.PlatformType.Static)
					platform.transform.position = platform.GetComponent<GodPlatform>().GetStartPosition();
			}
		}
	}
}
