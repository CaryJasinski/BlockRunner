using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public static CameraManager manager;

	public GameObject cameraPrefab;
	public GameObject cameraInstance = null;

	void Awake()
	{          
		if(manager != null)    //if manager does exist, destroy this copy
			Destroy(gameObject);

		manager = this;
	}

	public void InitializeCamera(GameObject cameraTarget)
	{
		if(cameraInstance == null)
		{
			cameraInstance = (GameObject)Instantiate(cameraPrefab, cameraTarget.transform.position, Quaternion.identity);
		}

		if(cameraInstance != null)
		{
			if(cameraTarget.tag == "Player")
			{
				cameraInstance.GetComponent<CameraLock>().SetCameraTargetPlayer(cameraTarget);
				cameraInstance.transform.position = cameraTarget.transform.position;
			}
		}
	}
}
