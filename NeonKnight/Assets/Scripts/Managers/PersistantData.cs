using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PersistantData : MonoBehaviour 
{
	//script variable of itself 
	public static PersistantData persistantDataController;
	
	//inventory
	public int bytes = 0;
	public int bits = 0;
	
	//level unlocks
	public int lastLevelCompleted = 0;
	public bool level01Unlock = true;
	public bool level02Unlock = false;
	public bool level03Unlock = false;
	public bool level04Unlock = false;
	public bool level05Unlock = false;
	public bool level06Unlock = false;
	public bool level07Unlock = false;
	public bool level08Unlock = false;
	public bool level09Unlock = false;
	public bool level10Unlock = false;
	
	//create controller in each scene and persist and replace/destroy anything that is not this
	void Awake () 
	{
		if(persistantDataController == null)
		{
			DontDestroyOnLoad(gameObject);
			persistantDataController = this;
		} else if(persistantDataController != null)
		{
			Destroy(gameObject);
		}
		LoadAllData();
	}
	
	public void SaveAllData()
	{
		Debug.Log ("SavedAll");
		SavePlayerInventory();
		SavePlayerLevelUnlocks();
	}
	
	public void LoadAllData()
	{
		Debug.Log ("LoadedAll");
		LoadPlayerInventory();
		//LoadPlayerLevelUnlocks();
	}
	
	//saving only inventory data
	public void SavePlayerInventory()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
		PlayerProfileData data = new PlayerProfileData ();

		data.bytes = bytes;
		data.bits = bits;
		
		bf.Serialize(file, data);
		file.Close();
	}
	
	//saving only level data
	public void SavePlayerLevelUnlocks()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInventory.dat");
		PlayerProfileData data = new PlayerProfileData ();

		data.lastLevelCompleted = lastLevelCompleted;

		data.level01Unlock = level01Unlock;
		data.level02Unlock = level02Unlock;
		data.level03Unlock = level03Unlock;
		data.level04Unlock = level04Unlock;
		data.level05Unlock = level05Unlock;
		data.level06Unlock = level06Unlock;
		data.level07Unlock = level07Unlock;
		data.level08Unlock = level08Unlock;

		bf.Serialize(file, data);
		file.Close();
	}
	
	//loading only inventory data
	public void LoadPlayerInventory()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerProfileData data = (PlayerProfileData)bf.Deserialize(file);
			file.Close ();

			bytes = data.bytes;
			bits = data.bits;
		}
	}
	
	//load only level unlocks
	public void LoadPlayerLevelUnlocks()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "/playerInventory.dat", FileMode.Open);
		PlayerProfileData data = (PlayerProfileData)bf.Deserialize(file);
		file.Close ();

		lastLevelCompleted = data.lastLevelCompleted;
		level01Unlock = data.level01Unlock;
		level02Unlock = data.level02Unlock;
		level03Unlock = data.level03Unlock;
		level04Unlock = data.level04Unlock;
		level05Unlock = data.level05Unlock;
		level06Unlock = data.level06Unlock;
		level07Unlock = data.level07Unlock;
		level08Unlock = data.level08Unlock;
	}
}

//clean class to use to equate player data values
[Serializable]
public class PlayerProfileData
{
	public int bytes;
	public int bits;
	
	public int lastLevelCompleted;
	public bool level01Unlock = false;
	public bool level02Unlock = false;
	public bool level03Unlock = false;
	public bool level04Unlock = false;
	public bool level05Unlock = false;
	public bool level06Unlock = false;
	public bool level07Unlock = false;
	public bool level08Unlock = false;
	public bool level09Unlock = false;
	public bool level10Unlock = false;
}
