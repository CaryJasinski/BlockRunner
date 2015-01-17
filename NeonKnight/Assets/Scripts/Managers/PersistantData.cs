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
	public int playerLives = 5;
	public int bits = 0;
	public int bytes = 0;
	public int megaBytes = 0;
	
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

	public bool[][] megaBytesPerLevel = new bool[10][]; //The array size should be equal to the number of levels in the game
	public bool[] level01MegaBytes = new bool[3];
	public bool[] level02MegaBytes = new bool[3];
	public bool[] level03MegaBytes = new bool[3];
	public bool[] level04MegaBytes = new bool[3];
	public bool[] level05MegaBytes = new bool[3];
	public bool[] level06MegaBytes = new bool[3];
	public bool[] level07MegaBytes = new bool[3];
	public bool[] level08MegaBytes = new bool[3];
	public bool[] level09MegaBytes = new bool[3];
	public bool[] level10MegaBytes = new bool[3];
	
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

		for(int index = 0; index < megaBytesPerLevel.Length; index++)
			megaBytesPerLevel[index] = new bool[3];

#if UNITY_EDITOR
		SaveAllData();//This line needs to be removed after testing
#endif
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
		data.Init();

		data.bits = bits;
		data.bytes = bytes;
		data.megaBytes = megaBytes;

		for(int i = 0; i < megaBytesPerLevel.Length; i++)
		{
			for(int j = 0; j < megaBytesPerLevel[i].Length; j++)
			{
				//Debug.Log(i + " : " + megaBytesPerLevel[i][j]);
				data.megaBytesPerLevel[i][j] = megaBytesPerLevel[i][j];
			}
		}

		data.level01MegaBytes = level01MegaBytes;
		data.level02MegaBytes = level02MegaBytes;
		data.level03MegaBytes = level03MegaBytes;
		data.level04MegaBytes = level04MegaBytes;
		data.level05MegaBytes = level05MegaBytes;
		data.level06MegaBytes = level06MegaBytes;
		data.level07MegaBytes = level07MegaBytes;
		data.level08MegaBytes = level08MegaBytes;
		data.level09MegaBytes = level09MegaBytes;
		data.level10MegaBytes = level10MegaBytes;
		
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
		data.level09Unlock = level09Unlock;
		data.level10Unlock = level10Unlock;
		
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

			bits = data.bits;
			bytes = data.bytes;
			megaBytes = data.megaBytes;

			for(int i = 0; i < megaBytesPerLevel.Length; i++)
			{
				for(int j = 0; j < megaBytesPerLevel[i].Length; j++)
				{
					//Debug.Log(i + " : " + data.megaBytesPerLevel[i][j]);
					megaBytesPerLevel[i][j] = data.megaBytesPerLevel[i][j];
				}
			}

			level01MegaBytes = data.level01MegaBytes;
			level02MegaBytes = data.level02MegaBytes;
			level03MegaBytes = data.level03MegaBytes;
			level04MegaBytes = data.level04MegaBytes;
			level05MegaBytes = data.level05MegaBytes;
			level06MegaBytes = data.level06MegaBytes;
			level07MegaBytes = data.level07MegaBytes;
			level08MegaBytes = data.level08MegaBytes;
			level09MegaBytes = data.level09MegaBytes;
			level10MegaBytes = data.level10MegaBytes;
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
		level09Unlock = data.level09Unlock;
		level10Unlock = data.level10Unlock;
	}
}

//clean class to use to equate player data values
[Serializable]
public class PlayerProfileData
{

	public int playerLives = 5;
	
	public int bits = 0;
	public int bytes = 0;
	public int megaBytes = 0;
	
	public int lastLevelCompleted = 0;
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

	public bool[][] megaBytesPerLevel = new bool[10][];

	public bool[] level01MegaBytes = new bool[3];
	public bool[] level02MegaBytes = new bool[3];
	public bool[] level03MegaBytes = new bool[3];
	public bool[] level04MegaBytes = new bool[3];
	public bool[] level05MegaBytes = new bool[3];
	public bool[] level06MegaBytes = new bool[3];
	public bool[] level07MegaBytes = new bool[3];
	public bool[] level08MegaBytes = new bool[3];
	public bool[] level09MegaBytes = new bool[3];
	public bool[] level10MegaBytes = new bool[3];


	public void Init()
	{
		for(int index = 0; index < megaBytesPerLevel.Length; index++)
			megaBytesPerLevel[index] = new bool[3];
	}
}