using UnityEngine;
using System.Collections;

public class PersistantObject : MonoBehaviour {

	public static PersistantObject persistantObject;

	void Awake()
	{          
		if(persistantObject == null)           //If manager doesn't exist, create one
		{
			DontDestroyOnLoad(gameObject);
			persistantObject = this;
		} else if(persistantObject != null)    //if manager does exist, destroy this copy
		{
			Destroy(gameObject);
		}
		persistantObject = this;
	}

}
