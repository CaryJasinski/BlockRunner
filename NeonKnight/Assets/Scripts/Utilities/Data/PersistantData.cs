using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PersistantData : MonoBehaviour 
{
	//script variable of itself 
	public static PersistantData data;
	
	public int playerLives = 5;
	public int bits = 0;
	public int lastLevelCompleted = 0;
	public bool[] levelUnlocks = new bool[10];
	public bool[][] megaBytesPerLevel = new bool[10][]; //The array size should be equal to the number of levels in the game
	
	//create controller in each scene and persist and replace/destroy anything that is not this
	void Awake () 
	{
		if(data == null)
		{
			DontDestroyOnLoad(gameObject);
			data = this;
		} else if(data != null)
		{
			Destroy(gameObject);
		}

		for(int index = 0; index < megaBytesPerLevel.Length; index++)
			megaBytesPerLevel[index] = new bool[3];

#if UNITY_EDITOR
		SaveAllData();//REMOVE: This line needs to be removed after testing
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
		PlayerProfileData tempData = new PlayerProfileData ();
		tempData.Init();

		tempData.bits = bits;

		for(int i = 0; i < megaBytesPerLevel.Length; i++)
		{
			for(int j = 0; j < megaBytesPerLevel[i].Length; j++)
			{
				//Debug.Log(i + " : " + megaBytesPerLevel[i][j]);
				tempData.megaBytesPerLevel[i][j] = megaBytesPerLevel[i][j];
			}
		}
		
		bf.Serialize(file, tempData);
		file.Close();
	}
	
	//saving only level data
	public void SavePlayerLevelUnlocks()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInventory.dat");
		PlayerProfileData tempData = new PlayerProfileData ();
		
		tempData.lastLevelCompleted = lastLevelCompleted;
		
		for(int index = 0; index < levelUnlocks.Length; index++)
			tempData.levelUnlocks[index] = levelUnlocks[index]; 
		
		bf.Serialize(file, tempData);
		file.Close();
	}
	
	//loading only inventory data
	public void LoadPlayerInventory()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			PlayerProfileData tempData = (PlayerProfileData)bf.Deserialize(file);
			file.Close ();

			bits = tempData.bits;

			for(int i = 0; i < megaBytesPerLevel.Length; i++)
			{
				for(int j = 0; j < megaBytesPerLevel[i].Length; j++)
				{
					//Debug.Log(i + " : " + data.megaBytesPerLevel[i][j]);
					megaBytesPerLevel[i][j] = tempData.megaBytesPerLevel[i][j];
				}
			}
		}
	}
	
	//load only level unlocks
	public void LoadPlayerLevelUnlocks()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Open(Application.persistentDataPath + "/playerInventory.dat", FileMode.Open);
		PlayerProfileData tempData = (PlayerProfileData)bf.Deserialize(file);
		file.Close ();
		
		lastLevelCompleted = tempData.lastLevelCompleted;
		for(int index = 0; index < levelUnlocks.Length; index++)
			levelUnlocks[index] = tempData.levelUnlocks[index];
	}
}

//clean class to use to equate player data values
[Serializable]
public class PlayerProfileData
{
	public int playerLives = 5;
	public int bits = 0;
	public int lastLevelCompleted = 0;
	public bool[] levelUnlocks = new bool[10];
	public bool[][] megaBytesPerLevel = new bool[10][];

	public void Init()
	{
		for(int index = 0; index < megaBytesPerLevel.Length; index++)
			megaBytesPerLevel[index] = new bool[3];
	}
}